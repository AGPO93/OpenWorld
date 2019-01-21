using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAI : MonoBehaviour
{
    public int currentArea;
    private GameObject player;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Chase();
    }

    private void Chase()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (Vector3.Distance(player.transform.position, this.transform.position) < 10 && angle < 30)
        // If in field of view and within distance.
        {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                      Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);

            if (direction.magnitude > 2)
            // Chase.
            {
                this.transform.Translate(0, 0, 0.5f); //0.05  <<<< OLD SPEED VALUE
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
            // Attack.
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
        }
        else
        // Back to Idle.
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
    }

    public void updateArea(int new_area)
    {
        currentArea = new_area;
    }
}
