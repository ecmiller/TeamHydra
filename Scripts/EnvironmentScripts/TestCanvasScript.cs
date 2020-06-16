using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestCanvasScript : MonoBehaviour
{
    public static TestCanvasScript instance;
    public GameObject imageTwo;

    [SerializeField]
    public float coinSpeed;

    public bool canvas;

    [SerializeField]
    TextMeshProUGUI coinCounter_TMP;

    [SerializeField]
    public GameObject theCanvas;



    public int coinCount;

    private void Awake()
    {

        //if (instance == null)
        //{
        //    instance = this;
        //}
        //DontDestroyOnLoad(this);
    }

    void Start()
    {
        //theCanvas.SetActive(false);
        coinCount = 0;
        canvas = false;
    }

    public void UpdateCoinCounterUI()
    {
        canvas = true;
        //theCanvas.SetActive(true);

        coinCounter_TMP.text = coinCount.ToString();

        //Invoke("TurnOffCanvas", 5f);
    }

    //public void TurnOffCanvas()
    //{
       
    //    theCanvas.SetActive(false);
    //    canvas = false;
    //}
}
