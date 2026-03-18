using UnityEngine;

public class Boards : MonoBehaviour
{
    [SerializeField] private Door door;
    private int boards = 0; 

    private void Start()
    {
        foreach (Transform child in transform)
        {
            boards++;
        }
    }

    public void RemoveBoard()
    {
        boards--;

        if (boards == 0)
        {
            door.Unlock();
            Destroy(gameObject);
        }
    }
}
