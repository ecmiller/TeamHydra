using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectiveWalls : MonoBehaviour
{
    [SerializeField] GameObject leftPanel;
    [SerializeField] GameObject rightPanel;
    public bool turnLeft;
    public bool turnRight;
    public int leftTurns;
    public int rightTurns;

    [SerializeField] Quaternion originalTransform;
    [SerializeField] GameObject gameManager;
    //[SerializeField] bool isRespawning;
    [SerializeField] Color color;
    private void Awake ()
    {
        color = GetComponent<MeshRenderer> ().material.color;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalTransform = transform.rotation;
        gameManager = GameObject.Find ("GameManager");

    }

    // Update is called once per frame
    void Update ()
    {
        //if (isRespawning == false)
        //{
        
        turnLeft = leftPanel.GetComponent<TurnReflectiveWall> ().turnLeft;
        turnRight = rightPanel.GetComponent<TurnReflectiveWall> ().turnRight;
        //isRespawning = gameManager.GetComponent<GameManagerScript> ().isRespawning;

        //if (leftTurns > 3)
        //{
        //    leftTurns = 3;
        //    //leftPanel.GetComponent<TurnReflectiveWall> ().turnLeft = false;
        //} 
        //else if (leftTurns < 3)
        //{
        if (turnLeft == true)
        {
            this.gameObject.transform.Rotate (-Vector3.up, 15f);
            leftPanel.GetComponent<TurnReflectiveWall> ().turnLeft = false;
        }
        //}

        //if (leftTurns < -3)
        //{
        //    leftTurns = -3;
        //    //leftPanel.GetComponent<TurnReflectiveWall> ().turnLeft = false;
        //}


        //if (rightTurns > 3)
        //{
        //    rightTurns = 3;
        //    //rightPanel.GetComponent<TurnReflectiveWall> ().turnRight = false;
        //}
        //else if(rightTurns < 3)
        //{
        if (turnRight == true)
        {
            this.gameObject.transform.Rotate (Vector3.up, 15f);
            rightPanel.GetComponent<TurnReflectiveWall> ().turnRight = false;
        }
        //}
        //if (rightTurns < -3)
        //{
        //    rightTurns = -3;
        //    //rightPanel.GetComponent<TurnReflectiveWall> ().turnRight = false;
        //}
        if (GetComponent<MeshRenderer> ().material.color != Color.white)
        {
            GetComponent<Renderer> ().material.color = Color.Lerp (GetComponent<MeshRenderer> ().material.color, Color.white, 10 * Time.deltaTime);
        }
        else
        {
            GetComponent<MeshRenderer> ().material.SetColor ("_EmissionColor", color);
        }
    }

        /*
         * if (isRespawning == true)
        {
            ResetReflectiveWalls ();
        }
    }
    */

    public void ResetReflectiveWalls ()
    {
        transform.rotation = originalTransform;
        turnLeft = false;
        turnRight = false;
        leftTurns = 0;
        rightTurns = 0;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("BombWall");
        }
    }
}
