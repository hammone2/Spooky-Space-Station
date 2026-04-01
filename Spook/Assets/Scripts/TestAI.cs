using UnityEngine;

public class TestAI : MonoBehaviour
{
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float chaseSpeed;

    private enum States
    {
        IDLE,
        PATROL,
        CHASE,
        ATTACK
    }
    private States state = States.IDLE;
    private AIMovement movement;
    [SerializeField] private Sensor sensor;


    private void Awake()
    {
        movement = GetComponent<AIMovement>();
        movement.OnDestinationReached.AddListener(OnTargetReached);
    }

    private void Start()
    {
        Patrol();
    }

    public void Chase()
    {
        movement.MoveToDestination(Player.Instance.transform.position, chaseSpeed);
        state = States.CHASE;
    }

    public void Patrol()
    {
        movement.Patrol(patrolSpeed);
        state = States.PATROL;
    }


    private void OnTargetReached()
    {
        switch (state)
        {
            case States.IDLE:
                return;

            case States.PATROL:
                Patrol();
                return;

            case States.CHASE:
                if (sensor.isActive)
                    Chase();
                else
                    Patrol();
                return;

            case States.ATTACK:
                return;
        }
    }
}
