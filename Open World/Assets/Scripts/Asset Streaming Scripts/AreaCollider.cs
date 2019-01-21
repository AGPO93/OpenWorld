using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCollider : MonoBehaviour
{
    public int AreaID;
    [SerializeField]
    private GameObject resourceLoader;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            resourceLoader.GetComponent<LoadObjects>().UpdatePlayerArea(gameObject);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            col.GetComponent<AIAreaManager>().updateArea(AreaID);
        }
    }
}
