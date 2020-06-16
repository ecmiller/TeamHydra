using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CollectCoins : MonoBehaviour
{
    public int rotationSpeed = 250;
    MeshRenderer testCoin;

    private void Start()
    {
        testCoin = GetComponent<MeshRenderer>();
        transform.rotation = Quaternion.Euler(90, 0, 0);
        transform.Translate(new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3)), Space.World);
        StartCoroutine(coinDisappear());
        StartCoroutine(flashing());
    }

    IEnumerator flashing()
    {
        yield return new WaitForSeconds(5);

        while (true)
        {
            yield return new WaitForSeconds(.3f);
            testCoin.enabled = !testCoin.enabled;
        }
    }

    IEnumerator coinDisappear()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
        
    }   

    private void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find ("CoinCounterUI").GetComponent<TestCanvasScript> ().coinCount++;
            GameObject.Find ("CoinCounterUI").GetComponent<TestCanvasScript> ().UpdateCoinCounterUI ();
            //TestCanvasScript.instance.coinCount++;
            //TestCanvasScript.instance.UpdateCoinCounterUI();
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Coin");
            Destroy(gameObject);
        }
    }


}
