using UnityEngine;

public class Door : MonoBehaviour
{
    private enum DoorStates
    {
        Unlocked,
        Locked,
        Inaccessible
    }
    [SerializeField] private DoorStates doorState;


    public void Unlock()
    {
        if (doorState == DoorStates.Inaccessible)
            return;
        
        doorState = DoorStates.Unlocked;
        Open();
    }

    public void Lock()
    {
        if (doorState == DoorStates.Inaccessible)
            return;

        doorState = DoorStates.Locked;
        Close();
    }

    public void Open()
    {
        if (doorState != DoorStates.Unlocked)
            return;

        //animation + other stuff 
    }

    public void Close()
    {
        if (doorState != DoorStates.Unlocked)
            return;

        //animation + other stuff
    }
}
