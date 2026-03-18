using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float health = 100f;
    public UnityEvent OnDamageTaken;
    public UnityEvent OnKilled;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
            OnKilled.Invoke();
            return;
        }

        OnDamageTaken.Invoke();
    }
}
