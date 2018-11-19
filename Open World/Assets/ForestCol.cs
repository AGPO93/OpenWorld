using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForestCol : MonoBehaviour
{
    public Scene osdk;

    void OnTriggerEnter()
    {
        SceneManager.UnloadSceneAsync(3);
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }
}
