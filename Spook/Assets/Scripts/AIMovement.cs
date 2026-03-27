using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class AIMovement : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    private NavMeshAgent agent;
    private int previousPatrolRoute;
    private bool destinationReached = true;
    public UnityEvent OnDestinationReached;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToDestination(Vector3 destination, float speed)
    {
        destinationReached = false;
        agent.isStopped = false;
        agent.SetDestination(destination);
        agent.speed = speed;
    }

    public void Patrol(float speed)
    {
        int patrolRouteIndex;
        do
        {
            patrolRouteIndex = Random.Range(0, patrolPoints.Length);
        } while (patrolRouteIndex == previousPatrolRoute);

        MoveToDestination(patrolPoints[patrolRouteIndex].position, speed);
    }

    private void Update()
    {
        if (destinationReached)
            return;

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.isStopped = true;
                destinationReached = true;
                OnDestinationReached.Invoke();
            }
        }
    }
}
