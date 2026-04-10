using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private float chaseSpeed;
    private bool destinationReached = true;

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

    public void Chase()
    {
        MoveToDestination(Player.Instance.transform.position, chaseSpeed);
    }
}
