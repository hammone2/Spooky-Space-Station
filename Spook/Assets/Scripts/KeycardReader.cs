using UnityEngine;
using UnityEngine.Events;

public class KeycardReader : MonoBehaviour
{
    [SerializeField] private Door door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Keycard")
            door.Unlock();
    }
}
