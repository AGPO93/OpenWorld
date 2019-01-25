using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public int identifier;
    public static bool forest, desert, canyon;

    void Awake()
    {
        desert = true;
        forest = false;
    }

    void OnTriggerEnter()
    {
        switch (identifier)
        {
            // forest
            case 1:

                if (!canyon)
                {
                    SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
                    canyon = true;
                }
                SceneManager.UnloadSceneAsync(3);
                desert = false;
                break;

            // canyon
            case 2:

                if (!forest)
                {
                    SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
                    forest = true;
                }

                if (!desert)
                {
                    SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
                    desert = true;
                }
                break;

            // desert
            case 3:

                if (!canyon)
                {
                    SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
                    canyon = true;
                }

                if (forest)
                {
                    SceneManager.UnloadSceneAsync(1);
                }
                forest = false;
                break;
        }
    }
}