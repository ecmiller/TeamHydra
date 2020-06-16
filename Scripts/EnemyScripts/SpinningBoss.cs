using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBoss : MonoBehaviour
{
    [SerializeField] GameObject[] SpinningEnemies;
    private int BossHealth;

    [SerializeField] GameObject BossHealthBar;

    public int enemyDefeated;

    public float pushBackForce;

    // Start is called before the first frame update
    void Start()
    {
        BossHealthBar = GameObject.Find("BossHealthBar");
        BossHealthBar.GetComponent<BossHealthBar>().isBossActive = true;

    }

    // Update is called once per frame
    void Update()
    {

        BossHealth = GetComponent<Damage>().damageTaken;

        if (BossHealth >= 4)
            Destroy(SpinningEnemies[4]);
        if (BossHealth >= 8)
            Destroy(SpinningEnemies[3]);
        if (BossHealth >= 12)
            Destroy(SpinningEnemies[2]);
        if (BossHealth >= 16)
            Destroy(SpinningEnemies[1]);
        if (BossHealth >= 20)
            Destroy(SpinningEnemies[0]);
        if (BossHealth >= 24)
        {
            GameObject.Find("ArenaBattle").GetComponent<BattleArena>().EnemyDefeated();
            BossHealthBar.GetComponent<BossHealthBar>().isBossActive = false;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag ("Player"))
        {

            collision.gameObject.GetComponent<BR_PlayerHealth> ().DamagePlayer (1);

            // Knocks the player away when hit
            collision.gameObject.GetComponent<Rigidbody> ().AddForce (-10, 0, 0);

            return;
        }

        if (collision.gameObject.CompareTag ("Wall"))
        {
            Debug.Log (name + " hit a wall");

            if (collision.gameObject.GetComponent<NormalWall> ())
            {
                if (collision.gameObject != null)
                {
                    collision.gameObject.GetComponent<NormalWall> ().isHit = true;
                    GetComponent<Rigidbody> ().AddRelativeForce (Vector3.back * pushBackForce, ForceMode.Impulse);
                }
            }

            else
            {
                Debug.Log (name + " hit something tagged as wall but nothing happened");
            }
        }
    }
}