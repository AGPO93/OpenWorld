using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// make it stop for x amount of time when it reaches a path node
// chase after player until distance from nodes, then go back to patrolling
// set destination player for chasing
// use enum states for attacking, patrolling and chasing states

public class SkeletonAI : MonoBehaviour
{
    private GameObject player;
    private Animator anim;
    private bool roaming = false;
    NavMeshAgent navMeshAgent;

    private GameObject nodeOne, nodeTwo, nodeThree;
    [HideInInspector]
    public string node1, node2, node3;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        player = GameObject.Find("Player");
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        nodeOne = GameObject.Find(node1);
        nodeTwo = GameObject.Find(node2);
        nodeThree = GameObject.Find(node3);
    }

    private void Update()
    {
        Roam();
    }

    private void Chase() // delete
    {
        Vector3 direction = player.transform.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (Vector3.Distance(player.transform.position, this.transform.position) < 10 && angle < 30) // use this for new chasing function
        // If in field of view and within distance.
        {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                      Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);

            if (direction.magnitude > 2)
            // Chase.
            {
                this.transform.Translate(0, 0, 0.5f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
            // use for new attacking function
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

    private void SetDestination(GameObject waypoint)
    {
        Vector3 targetVector = waypoint.transform.position;
        navMeshAgent.SetDestination(targetVector);

        // Start walking animation.
        anim.SetBool("isWalking", true);
        anim.SetBool("isAttacking", false);
    }

    private void Roam()
    {
        if (roaming == false)
        {
            SetDestination(nodeOne);
            roaming = true;
        }
        else if (Vector3.Distance(this.transform.position, nodeOne.transform.position) <= 5)
        {
            SetDestination(nodeTwo);
        }
        else if (Vector3.Distance(this.transform.position, nodeTwo.transform.position) <= 5)
        {
            SetDestination(nodeThree);
        }
        else if (Vector3.Distance(this.transform.position, nodeThree.transform.position) <= 5)
        {
            SetDestination(nodeOne);
        }
    }
}
