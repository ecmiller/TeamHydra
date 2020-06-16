using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAdditive  : MonoBehaviour
{
    [SerializeField] string SceneName;
   public void Load()
    {
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Load();
        }
    }
}
