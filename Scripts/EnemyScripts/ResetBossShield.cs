using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ResetBossShield : MonoBehaviour
{
    [SerializeField] GameObject BossShield;
    [SerializeField] GameObject BossEnemy;
    [SerializeField] GameObject[] ShieldingEnemies;
    [SerializeField] GameObject[] Turrets;
    [SerializeField] GameObject ShieldDeathEffect;
    [SerializeField] GameObject[] FireEffects;
    [SerializeField] GameObject FireAbsorbEffect;
    [SerializeField] GameObject TurretSpawnCylinders;
    [SerializeField] GameObject FlamePillarSpawner;
    [SerializeField] GameObject[] FlamePillars;
    [SerializeField] GameObject[] FireSpark;
    [SerializeField] GameObject[] Fireballs;
    [SerializeField] int FireBossMoveSpeed;
    [SerializeField] int ShieldedMoveSpeed;
    [SerializeField] GameObject CameraHolder;
    [SerializeField] GameObject CameraPointA;
    [SerializeField] GameObject CameraPointB;
    public int currentFireEffect;
    GameObject[] WallFire;
    GameObject Exit;
    private NavMeshAgent agent;
    public bool resetShield = false;
    public bool PhaseTwo = false;
    public bool PhaseThree = false;
    public float startTime;
    public float cameraDistance;
    public float cameraMoveSpeed;
    public float fractionOfJourney;

    void Start()
    {
        startTime = Time.time;
        cameraDistance = Vector3.Distance(CameraPointA.transform.position, CameraPointB.transform.position);

        Turrets = GameObject.FindGameObjectsWithTag("Turret");
        currentFireEffect = 0;
        for (int i = 0; i < FireEffects.Length; i++)
        {
            FireEffects[i].SetActive(false);
        }
        FireAbsorbEffect.SetActive(false);
        agent = GetComponent<NavMeshAgent>();
        WallFire = GameObject.FindGameObjectsWithTag("Fire");
        Exit = GameObject.Find("NextLevelTrigger");
        Exit.SetActive(false);
        for (int i = 0; i < WallFire.Length; i++)
        {
            WallFire[i].SetActive(false);
        }
    }

   
    void Update()
    {
        //float distCovered = (Time.time - startTime) * cameraMoveSpeed;
        //fractionOfJourney = distCovered / cameraDistance;

        Fireballs = GameObject.FindGameObjectsWithTag("TrackingFireball");
        FlamePillars = GameObject.FindGameObjectsWithTag("BurnEffect");
        FireSpark = GameObject.FindGameObjectsWithTag("FireSpark");
    }

    public void BossKilled()
    {
        agent = GetComponent<NavMeshAgent>();
        WallFire = GameObject.FindGameObjectsWithTag("Fire");
        Exit.SetActive(true);
        for (int i = 0; i < WallFire.Length; i++)
        {
            WallFire[i].SetActive(false);
        }
    }
    public void StartFire()
    {
        if(PhaseThree == true)
        {
            BossEnemy.GetComponent<ShieldBossAttacks>().ShootFireball();
            FireEffects[currentFireEffect].SetActive(true);
        }
        if(PhaseTwo == true)
        {
            FlamePillarSpawner.GetComponent<EruptFlamePillar>().StartFlamePillar();
            FireEffects[currentFireEffect].SetActive(true);
        }

        FireEffects[currentFireEffect].SetActive(true);
        FireAbsorbEffect.SetActive(false);
        agent.GetComponent<NavMeshAgent>().speed = FireBossMoveSpeed;

        CameraHolder.transform.position = Vector3.Lerp(CameraPointA.transform.position, CameraPointB.transform.position, cameraMoveSpeed * Time.deltaTime);

        for (int i = 0; i < WallFire.Length; i++)
        {
            WallFire[i].SetActive(true);
        }

        for (int i = 0; i < Turrets.Length; i++)
        {
            Turrets[i].SetActive(false);
            Turrets[i].GetComponent<TurretScript>().StopShooting();
        }
    }

    void ReplaceShield()
    {
        for (int i = 0; i < FlamePillars.Length; i++)
        {
            Destroy(FlamePillars[i]);
        }

        for (int i = 0; i < FireSpark.Length; i++)
        {
            Destroy(FireSpark[i]);
        }

        for (int i = 0; i < Fireballs.Length; i++)
        {
            Destroy(Fireballs[i]);
        }

        GetComponent<ShieldBossAttacks>().StopShootingFireball();
        FlamePillarSpawner.GetComponent<EruptFlamePillar>().StopFlamePillars();
        TurretSpawnCylinders.GetComponent<Animator>().SetBool("isRising", false);
        if(Turrets != null)
        {
            for (int i = 0; i < Turrets.Length; i++)
            {
                Turrets[i].SetActive(true);
                Turrets[i].GetComponent<Damage>().damageTaken = 0;
            }
        }
        BossShield.SetActive(true);
        for (int i = 0; i < FireEffects.Length; i++)
        {
            FireEffects[i].SetActive(false);
        }
        gameObject.GetComponent<Damage>().isShieldDown = false;
    }

    public void ResetShield()
    {
        if (gameObject.CompareTag("ShieldBoss"))
        {
            gameObject.GetComponent<ShieldBossAttacks>().StopShootingFireball();
        }
        TurretSpawnCylinders.GetComponent<Animator>().SetBool("isRising", true);
        resetShield = false;
        Invoke("ReplaceShield", 0.7f);
        BossShield.GetComponent<Damage>().damageTaken = 0;
        BossShield.GetComponent<Damage>().damageTaken = 0;
        ShieldDeathEffect.SetActive(false);
        FireAbsorbEffect.SetActive(true);
        agent.GetComponent<NavMeshAgent>().speed = ShieldedMoveSpeed;

        CameraHolder.transform.position = Vector3.Lerp(CameraPointB.transform.position, CameraPointA.transform.position, cameraMoveSpeed * Time.deltaTime);

        for (int i = 0; i < ShieldingEnemies.Length; i++)
        {
            ShieldingEnemies[i].SetActive(true);
            ShieldingEnemies[i].GetComponent<Damage>().damageTaken = 0;
        }

        for (int i = 0; i < WallFire.Length; i++)
        {
            WallFire[i].SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if(FlamePillarSpawner != null)
        {
            FlamePillarSpawner.GetComponent<EruptFlamePillar>().StopFlamePillars();
        }

        for (int i = 0; i < FlamePillars.Length; i++)
        {
            Destroy(FlamePillars[i]);
        }

        for (int i = 0; i < FireSpark.Length; i++)
        {
            Destroy(FireSpark[i]);
        }

        if(Fireballs != null)
        {
            for (int i = 0; i < Fireballs.Length; i++)
            {
                Fireballs[i].GetComponent<TrackingFireball>().ExplodeFireBall();
                Destroy(Fireballs[i]);
            }
        }
    }
}
