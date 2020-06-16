using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

// Tutorial used: GRENADE/BOMB in Unity: https://youtu.be/BYL6JtUdEY0
// Tutorial used: Breakfast With Unity 5.0: Blocking Explosions With Walls: https://youtu.be/bSFN_xtLqNA

public class Bomb : MonoBehaviour
{
    public float fuseTimer = 3f;
    public float explosionRadius = 8f;
    public int bombDamage = 10;
    public float explosionForce = 300f;
    public float chainReactionDelay = 0.7f;
    public GameObject bombExplosionEffect;
    public bool isLit;
    public BombHalo halo;

    private bool isBeeping;
    private bool isHaloVisible;

    private BR_AudioManager audioManager;
    [SerializeField] private ParticleSystem fuseParticles;
    [SerializeField] private MeshRenderer bombBody;
    [SerializeField] private MeshRenderer bombNeck;
    [SerializeField] private Color warningColor;
    [SerializeField] private Light warningLight;
    [SerializeField] public bool hasExploded;

    private void Awake()
    {
        
        // Check to see if the halo has been assigned in the inspector
        if (!halo)
        {
            Debug.Log("No halo assigned to bomb " + gameObject.name);
        }

        // If the halo has been assigned, deactivate it until the bomb is about to explode
        else
        {
            halo.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isLit = false;
        hasExploded = false;
        isBeeping = false;
        isHaloVisible = false;

        // Set up and deactivate the particle system for the fuse (if not already assigned)
        if (!fuseParticles)
        {
            fuseParticles = gameObject.GetComponentInChildren<ParticleSystem>(true);
            if (!fuseParticles)
            {
                Debug.Log("The particle system for " + name + " was not assigned.");
            }
        }

        fuseParticles.gameObject.SetActive(false);

        // Set up and deactivate the light indicating the bomb's blast radius (if not already assigned)
        if (!warningLight)
        {
            warningLight = gameObject.GetComponentInChildren<Light>(true);
            if (!warningLight)
            {
                Debug.Log("The warning light for " + name + " was not assigned.");
            }
        }

        else
        {
            warningLight.transform.position = gameObject.transform.position;
        }

        audioManager = FindObjectOfType<BR_AudioManager>();

        if(audioManager == null)
        {
            Debug.Log("Bomb script couldn't find an audio manager in the scene");
        }

        warningLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        
        if (isLit)
        { 
            fuseTimer -= Time.deltaTime;

            if (fuseTimer <= 1f)
            {
                ChangeColor(warningColor);

                if (!isHaloVisible)
                {
                    // Turn on the explosion halo
                    halo.gameObject.SetActive(true);
                    isHaloVisible = true;
                }

                if (fuseTimer <= 0.75f && !isBeeping)
                {
                    Beep();
                }
            }

            if (fuseTimer <= 0f && !hasExploded)
            {
                Explode();
            }
        }
        
    }

    private void ChangeColor(Color lerpColor)
    {
        bombBody.material.color = Color.Lerp(bombBody.material.color, lerpColor, 1f);
        bombNeck.material.color = Color.Lerp(bombNeck.material.color, lerpColor, 1f);
        warningLight.color = Color.Lerp(warningLight.color, lerpColor, 1f);
    }

    private void Beep()
    {
        audioManager.Play("BombBeep");
        isBeeping = true;
    }

    private void Explode()
    {
        Instantiate(bombExplosionEffect, transform.position, transform.rotation);

        // Get a list of all the objects within the blast radius upon detonation
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider c in colliders)
        {
            Rigidbody rb = c.GetComponent<Rigidbody>();
            Damage damage = c.GetComponent<Damage>();
            NormalWall wall = c.GetComponent<NormalWall>();
            BombNormalWall bombwall = c.GetComponent<BombNormalWall>();
            Bomb bomb = c.GetComponent<Bomb>();
            BR_PlayerHealth playerHealth = c.GetComponent<BR_PlayerHealth>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            if (damage != null)
            {
                // Player was caught in the explosion
                if (playerHealth != null)
                {
                    // Perform a raycast. Deal damage if no obstructions exist between the explosion and player.
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, c.transform.position - transform.position, out hit, explosionRadius))
                    {
                        if (hit.collider.gameObject.CompareTag("Wall"))
                        {
                            Debug.Log("Player was protected from a bomb explosion by a wall");
                        }

                        else
                        {
                            playerHealth.DamagePlayer(bombDamage);
                        }
                    }
                }

                // Some other object capable of taking damage was caught in the explosion
                else
                {
                    damage.UpdateDamage(bombDamage);
                }
            }

            if (bomb != null)
            {
                bomb.LightFuse(chainReactionDelay);
            }

            if (wall != null)
            {
                wall.isHit = true;
            }

            if (bombwall != null)
            {
                bombwall.bombwallisHit = true;
            }
        }

        // Play explosion SFX and destroy the object
        audioManager.Stop("BombFuse");
        audioManager.Stop("BombBeep");
        audioManager.Play("BombExplosion");
        hasExploded = true;

        Destroy(gameObject);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // When the bomb is hit by the player's projectile, light the fuse and turn on the light
        if (collision.gameObject.CompareTag("Weapon"))
        {
            LightFuse();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("BombLanded");
        }
    }

    public void ChainReaction()
    {
        Debug.Log("Detonation of " + name + " was triggered by another bomb");
        Invoke("Explode", chainReactionDelay);
    }

    public void LightFuse()
    {
        fuseParticles.gameObject.SetActive(true);
        audioManager.Play("BombFuse");

        warningLight.gameObject.SetActive(true);
        warningLight.transform.localScale = new Vector3(explosionRadius, explosionRadius, explosionRadius);
        isLit = true;
    }

    public void LightFuse(float timeUntilDetonation)
    {
        LightFuse();
        fuseTimer = timeUntilDetonation;
    }
}
