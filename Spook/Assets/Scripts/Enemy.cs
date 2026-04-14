using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float attackDistance;
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


    public void StopMoving()
    {
        agent.isStopped = true;
        destinationReached = true;
    }


    IEnumerator Attack()
    {
        StopMoving();
        Player.Instance.GetComponent<Health>().TakeDamage(GetComponent<Weapon>().damage);

        yield return new WaitForSeconds(1f);

        Chase();
    }

    public void Update()
    {
        if (destinationReached)
            return;

        Chase();

        if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= attackDistance)
        {
            StartCoroutine(Attack());
        }
    }
}
