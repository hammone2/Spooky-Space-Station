using UnityEngine;

public class BallGame : MonoBehaviour
{
    public Transform dropPoint;
    public float interval = 0.5f;

    private float nextBallTime = 0f;
    private ObjectPooler objectPooler;

    private void Start()
    {
        nextBallTime = Time.time + interval;
        objectPooler = GetComponent<ObjectPooler>();
    }

    void Update()
    {
        if (Time.time > nextBallTime)
        {
            nextBallTime = Time.time + interval;
            NewBall(dropPoint.position);
        }
    }

    private void NewBall(Vector3 position)
    {
        GameObject ball = objectPooler.GetPooledObject();
        if (ball != null)
        {
            ball.transform.position = position;
            ball.transform.rotation = Quaternion.identity;
            ball.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
    }
}
