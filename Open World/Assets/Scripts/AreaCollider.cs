using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCollider : MonoBehaviour
{
    [SerializeField]
    private int AreaID;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            col.GetComponent<Controller>().currentArea = AreaID;
        }
    }

}
