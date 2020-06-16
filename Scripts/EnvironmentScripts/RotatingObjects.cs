using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObjects : MonoBehaviour
{
    [SerializeField] GameObject PointA;
    [SerializeField] GameObject PointB;

    [SerializeField] bool isActive;
    [SerializeField] float speed = 5;
    [SerializeField] bool movingRight;
    [SerializeField] bool movingLeft;

    private void Awake()
    {
        //this.gameObject.transform.position = PointA.transform.position;
        isActive = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == true)
        {
            transform.Rotate(new Vector3(0f, 0f, 100f) * Time.deltaTime);

            if (this.gameObject.transform.position == PointA.transform.position)
            {
                movingRight = true;
                movingLeft = false;
            }
            else if (this.gameObject.transform.position == PointB.transform.position)
            {
                movingLeft = true;
                movingRight = false;
            }

            if (movingRight == true)
            {
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, PointB.transform.position, speed * Time.deltaTime);
            }

            if (movingLeft == true)
            {
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, PointA.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
      

    
