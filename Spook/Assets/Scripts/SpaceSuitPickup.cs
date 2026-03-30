using UnityEngine;

public class SpaceSuitPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player)
        {
            player.hasSpaceSuit = true;
            Destroy(gameObject);
        }
    }
}
