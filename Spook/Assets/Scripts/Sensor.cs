using UnityEngine;
using UnityEngine.Events;

public class Sensor : MonoBehaviour
{
    public UnityEvent OnPlayerEntered;
    public UnityEvent OnPlayerExited;
    public bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //I might want to change this later so it detects all entities. This will work for now though.
        {
            isActive = true;
            OnPlayerEntered.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isActive = false;
            OnPlayerExited.Invoke();
        }
    }
}
