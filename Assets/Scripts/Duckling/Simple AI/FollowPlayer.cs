using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float speed;
    NavMeshAgent agent;

    public Vector3 playerFollowDistance, maxDistanceApartPosition;
    public float maxDistanceApart;

    MotherDuckTrigger motherDuck;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        motherDuck = GameObject.FindGameObjectWithTag("MotherDuck").GetComponent<MotherDuckTrigger>();
        
    }

    void Update()
    {
        if (!motherDuck.motherDuckReached)
        {
            agent.SetDestination(player.position - playerFollowDistance);
            transform.LookAt(player.transform.position);

            if (Vector3.Distance(player.position, transform.position) > maxDistanceApart)
            {
                transform.position = player.position - maxDistanceApartPosition;
            }
        }
        else
        {
            agent.SetDestination(motherDuck.transform.position - playerFollowDistance);
            transform.LookAt(player.transform.position);
        }
    }
}
