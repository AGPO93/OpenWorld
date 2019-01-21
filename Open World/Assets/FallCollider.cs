using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
}
