using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using TMPro;

public class ScoreEffect: MonoBehaviour
{
    [SerializeField] Vector3 maxScale;
    [SerializeField] Vector3 normalScale;
    private float TimeScale;

    // Start is called before the first frame update
    void Start ()
    {
        normalScale = new Vector2 (1, 1);
        maxScale = new Vector2 (1.5f, 1.5f);
        TimeScale = 3f;
    }

    // Update is called once per frame
    void Update ()
    {
        //this.gameObject.transform.localScale = Vector3.Lerp (normalScale, maxScale, Time.deltaTime * .1f);
    }

    IEnumerator LerpUp ()
    {
        float progress = 0;

        while (progress <= 1)
        {
            this.gameObject.GetComponent<TextMeshProUGUI> ().color = Color.red;
            transform.localScale = Vector3.Lerp (normalScale, maxScale, progress);
            progress += Time.deltaTime * TimeScale;
            yield return null;
        }
        transform.localScale = maxScale;

        if (transform.localScale == maxScale)
        {
            progress = 0;

            while (progress <= 1)
            {
                transform.localScale = Vector3.Lerp (maxScale, normalScale, progress);
                progress += Time.deltaTime * TimeScale;
                yield return null;
            }
            transform.localScale = normalScale;
            this.gameObject.GetComponent<TextMeshProUGUI> ().color = Color.white;

        }
    }
    public void TextEffect()
    {
        StartCoroutine (LerpUp ());
    }
}
