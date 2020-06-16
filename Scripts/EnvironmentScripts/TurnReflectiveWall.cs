using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnReflectiveWall : MonoBehaviour
{
    [SerializeField] bool leftPanel;
    [SerializeField] bool rightPanel;
    public bool turnLeft;
    public bool turnRight;
    [SerializeField] Color OriginalColor;
    [SerializeField] float leftTimer;
    [SerializeField] float rightTimer;
    [SerializeField] bool startLeftTimer;
    [SerializeField] bool startRightTimer;
    [SerializeField] GameObject LeftCube;
    [SerializeField] GameObject RightCube;
    [SerializeField] Color color;


    private void Awake ()
    {
        OriginalColor = LeftCube.GetComponent<Renderer> ().material.GetColor ("_Color");
        leftTimer = 0;
        rightTimer = 0;
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (startLeftTimer == true)
        {
            color = LeftCube.GetComponent<MeshRenderer> ().material.color;
            LeftCube.GetComponent<Renderer> ().material.color = new Color (1, 0.05f, 0);
            LeftCube.GetComponent<MeshRenderer> ().material.SetColor ("_EmissionColor", color);
            leftTimer += Time.deltaTime;
            LeftCube.GetComponent<Renderer> ().material.color = Color.Lerp (new Color (1, 0.05f, 0), OriginalColor, leftTimer);
        }

        if (startRightTimer == true)
        {
            color = RightCube.GetComponent<MeshRenderer> ().material.color;
            RightCube.GetComponent<Renderer> ().material.color = new Color (1, 0.05f, 0);
            RightCube.GetComponent<MeshRenderer> ().material.SetColor ("_EmissionColor", color);
            rightTimer += Time.deltaTime;
            RightCube.GetComponent<Renderer> ().material.color = Color.Lerp (new Color (1, 0.05f, 0), OriginalColor, rightTimer);
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag ("Weapon"))
        {
            if (leftPanel == true)
            {
                startLeftTimer = false;
                leftTimer = 0;
                startLeftTimer = true;

                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("LeftPanel");
                if (this.gameObject.transform.parent.gameObject.GetComponent<ReflectiveWalls> ().leftTurns < 3 && this.gameObject.transform.parent.gameObject.GetComponent<ReflectiveWalls> ().leftTurns > -3)
                {
                    turnLeft = true;
                    this.gameObject.transform.parent.gameObject.GetComponent<ReflectiveWalls> ().leftTurns++;
                    this.gameObject.transform.parent.gameObject.GetComponent<ReflectiveWalls> ().rightTurns--;
                }

                if (this.gameObject.transform.parent.gameObject.GetComponent<ReflectiveWalls> ().rightTurns == 3)
                {
                    turnLeft = true;
                    this.gameObject.transform.parent.gameObject.GetComponent<ReflectiveWalls> ().leftTurns++;
                    this.gameObject.transform.parent.gameObject.GetComponent<ReflectiveWalls> ().rightTurns--;
                }
                

            }

            if (rightPanel == true)
            {
                startRightTimer = false;
                rightTimer = 0;
                startRightTimer = true;

                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("RightPanel");
                if (this.gameObject.transform.parent.gameObject.GetComponent<ReflectiveWalls> ().rightTurns < 3 && this.gameObject.transform.parent.gameObject.GetComponent<ReflectiveWalls> ().rightTurns > -3)
                {
                    turnRight = true;
                    this.gameObject.transform.parent.gameObject.GetComponent<ReflectiveWalls> ().rightTurns++;
                    this.gameObject.transform.parent.gameObject.GetComponent<ReflectiveWalls> ().leftTurns--;
                }

                if (this.gameObject.transform.parent.gameObject.GetComponent<ReflectiveWalls> ().leftTurns == 3)
                {
                    turnRight = true;
                    this.gameObject.transform.parent.gameObject.GetComponent<ReflectiveWalls> ().rightTurns++;
                    this.gameObject.transform.parent.gameObject.GetComponent<ReflectiveWalls> ().leftTurns--;
                }
            }

        }
    }
}
