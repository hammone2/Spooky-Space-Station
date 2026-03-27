using UnityEngine;

public class TestAI : MonoBehaviour
{
    private enum States
    {
        IDLE,
        PATROL,
        CHASE,
        ATTACK
    }
    private States state = States.IDLE;
    private AIMovement movement;


    private void Awake()
    {
        movement = GetComponent<AIMovement>();
    }

    private void SwitchState(States state)
    {
        switch (state)
        {
            case States.IDLE:
                return;

            case States.PATROL:
                return;

            case States.CHASE:
                return;

            case States.ATTACK:
                return;
        }
    }
}
