using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DucklingStateController : MonoBehaviour
{
    public DucklingState currentState;
    public DucklingStats ducklingStats;
    public Transform eyes;
    public DucklingState remainState;

    [HideInInspector] public NavMeshAgent agent;

    [HideInInspector] public float stateInterestLevel; //minStrollRange, maxStrollRange, minStateTime, maxStateTime,
    public Vector3 strollPoint;
    public bool strollPointSet;
    [HideInInspector] public DucklingObjectDetection detection;
    [HideInInspector] public Rigidbody rb;

    [HideInInspector] public Transform player;


    private bool aiActive;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        detection = GetComponent<DucklingObjectDetection>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        //stateTime = GenerateStateTime();
    }

    public void SetupAI(bool aiActivation, Vector3 waypoint)
    {
        strollPoint = waypoint;
        aiActive = aiActivation;
        if (aiActive)
        {
            agent.enabled = true;
        }
        else agent.enabled = false;
    }

    private void Update()
    {
        if (!aiActive) return;

        currentState.UpdateState(this);
    }

    private void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, ducklingStats.lookRadius);
        }
    }

    public void TransitionToState(DucklingState nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }
}
