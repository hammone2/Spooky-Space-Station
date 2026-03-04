using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public float minVelocity = 2.0f;
    public float maxVelocity = 10.0f;
    public float damageScalar = 50f;

    private Rigidbody rb;

    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.localPosition;
    }

    void Update()
    {
        //dont move when hitting stuff
        transform.localPosition = startPosition;
        transform.localRotation = Quaternion.identity;
    }

    void OnCollisionEnter(Collision other)
    {
        float speed = rb.linearVelocity.magnitude; //velocity.magnitude;

        //Apply damage
        if (speed >= minVelocity)
        {
            float damage = damageScalar * speed;

            Health target = other.collider.GetComponent<Health>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

        //Apply physics forces
        Rigidbody otherRb = other.collider.GetComponent<Rigidbody>();
        if (otherRb)
        {
            otherRb.AddForce(rb.angularVelocity.normalized * 0.5f, ForceMode.Impulse);
        }
    }
}
