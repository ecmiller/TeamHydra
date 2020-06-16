using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMetalWall : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Color OriginalColor;
    [SerializeField] float timer;
    [SerializeField] GameObject Laser;

    private void Awake ()
    {
        animator = GetComponent<Animator> ();
        animator.enabled = false;
        OriginalColor = GetComponent<Renderer> ().material.GetColor ("_Color");
        timer = 0;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.enabled == true)
        {
            timer += Time.deltaTime;
            GetComponent<Renderer> ().material.color = Color.Lerp (OriginalColor, new Color (1, 0.05f, 0), timer);

            if (timer >= 2f)
            {
                GetComponent<BoxCollider> ().enabled = false;
                Laser.GetComponent<RaycastReflection> ().DeactivateLaser ();
                this.enabled = false;
            }
        }
    }

    public void MeltWall ()
    {
        animator.enabled = true;
    }
}
