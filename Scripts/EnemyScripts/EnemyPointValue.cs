using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointValue : MonoBehaviour
{
    public int myPointValue;
    private ScoreScript s;

    // Start is called before the first frame update
    void Start()
    {
        s = FindObjectOfType<ScoreScript>();
    }

    //public void UpdateScore()
    //{
    //    if (s != null)
    //    {
    //        s.UpdateScore(myPointValue);
    //    }
    //}
}