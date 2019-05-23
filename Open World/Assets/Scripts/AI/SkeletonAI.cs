using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
// must also avoid leaving the area
// currently gets stuck after attacking player
// must go back to patrolling 
/// </summary>
/// 

public class SkeletonAI : MonoBehaviour
{
    private enum State
    {
        ROAM,
        CHASE,
        ATTACK
    }

    private State state;
    private Animator anim;
    NavMeshAgent navMeshAgent;
    private GameObject player;
    private bool roaming = false;
    private bool alive = true;
    // Patrolling.
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
        state = SkeletonAI.State.ROAM;
        StartCoroutine("FSM");
    }

    private void LateUpdate()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        Vector3 a = Vector3.Normalize(direction) * 10;

        Debug.DrawLine(transform.position, a + transform.position, Vector3.Distance(player.transform.position, this.transform.position) < 10 && angle < 60 ? Color.green : Color.red);

        // If in field of view and within distance.
        if (Vector3.Distance(player.transform.position, this.transform.position) < 10 && angle < 60)
        {
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                      Quaternion.LookRotation(direction), 0.1f);

            if (Vector3.Distance(this.transform.position, player.transform.position) > 3)
            {
                state = SkeletonAI.State.CHASE;
            }

        }

        if (Vector3.Distance(this.transform.position, nodeTwo.transform.position) > 30)
        {
            state = SkeletonAI.State.ROAM;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            state = SkeletonAI.State.ATTACK;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            state = SkeletonAI.State.ROAM;
        }
    }

    IEnumerator FSM()
    {
        while (alive)
        {
            switch (state)
            {
                case State.ROAM:
                    Roam();
                    break;
                case State.CHASE:
                    Chase();
                    break;
                case State.ATTACK:
                    Attack();
                    break;
            }
            yield return null;
        }
    }

    private void SetDestination(GameObject waypoint)
    {
        anim.SetBool("isAttacking", false);
        anim.SetBool("isWalking", true);
        Vector3 targetVector = waypoint.transform.position;
        navMeshAgent.SetDestination(targetVector);

    }

    private void Roam()
    {
        navMeshAgent.speed = 3;
        if (!roaming)
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

    private void Attack()
    {
        anim.SetBool("isAttacking", true);
        anim.SetBool("isWalking", false);
        if (roaming)
        {
            roaming = false;
        }
    }

    private void Chase()
    {
        navMeshAgent.speed = 5;
        SetDestination(player);
        if (roaming)
        {
            roaming = false;
        }
    }
}
