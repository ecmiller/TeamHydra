using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalWall : MonoBehaviour
{
    public bool heatUp;
    private bool isPlayingSound;
    public GameObject destroyedWall;
    private BR_AudioManager bR_Audio;
    [SerializeField] bool coolDown;
    [SerializeField] float timer;
    [SerializeField] float maxtimer;
    [SerializeField] Color OriginalColor;

    // Start is called before the first frame update
    void Start()
    {
        heatUp = false;
        isPlayingSound = false;

        bR_Audio = FindObjectOfType<BR_AudioManager>();
        if(bR_Audio == null)
        {
            Debug.Log("No audio manager found for the metal wall " + gameObject.name);
        }

        if(destroyedWall == null)
        {
            Debug.Log("No destroyed version of the metal wall was assigned in the inspector");
        }

        timer = 0;
        maxtimer = 3;
        OriginalColor = GetComponent<Renderer> ().material.GetColor ("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        if (heatUp == true)
        {
            coolDown = false;

            if (!isPlayingSound)
            {
                bR_Audio.Play("LaserMelt");
                isPlayingSound = true;
            }

            MeltMetalWall ();
        }

        else
        {
            coolDown = true;

            if (isPlayingSound)
            {
                bR_Audio.Stop("LaserMelt");
                isPlayingSound = false;
            }

            CoolMetalWall();
        }
    }

    public void MeltMetalWall ()
    {
        timer += Time.deltaTime;
        GetComponent<Renderer> ().material.color = Color.Lerp (OriginalColor, new Color(1,0.05f,0), timer);
        if (timer >= maxtimer)
        {
            // Play the shockwave sound effect when the wall is destroyed.
            bR_Audio.Stop("LaserMelt");
            bR_Audio.Play("Shockwave");

            //When the wall melts, make the metal wall invisible, turn off its collider, and make the destroyed version active
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            destroyedWall.SetActive(true);

            //Set the color of the destroyed wall's bits and pieces
            foreach(MeshRenderer m in destroyedWall.GetComponentsInChildren<MeshRenderer>())
            {
                m.material.color = OriginalColor;
            }

            //After a short delay, destroy the object
            Invoke("DestroyWall", 2.5f);
        }
    }

    public void CoolMetalWall ()
    {
        timer -= Time.deltaTime;
        GetComponent<Renderer> ().material.color = Color.Lerp (GetComponent<Renderer>().material.GetColor("_Color"),OriginalColor, Time.deltaTime);
        if (timer < 0)
        {
            timer = 0;
        }
    }

    private void DestroyWall()
    {
        Destroy(gameObject);
    }
}
