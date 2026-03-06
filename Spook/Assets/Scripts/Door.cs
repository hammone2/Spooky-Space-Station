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

    private Renderer renderer; //replace this later with light object ref
    [SerializeField] private Material greenLight;
    [SerializeField] private Material yellowLight;
    [SerializeField] private Material redLight;


    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        SwitchState(doorState);
    }


    public void Unlock()
    {
        if (doorState == DoorStates.Inaccessible)
            return;

        SwitchState(DoorStates.Unlocked);
        Open();
    }

    public void Lock()
    {
        if (doorState == DoorStates.Inaccessible)
            return;

        SwitchState(DoorStates.Locked);
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

    private void SwitchState(DoorStates newState)
    {
        doorState = newState;
        switch (doorState)
        {
            case DoorStates.Unlocked:
                renderer.material = greenLight;
                break;

            case DoorStates.Locked:
                renderer.material = yellowLight;
                break;

            case DoorStates.Inaccessible:
                renderer.material = redLight;
                break;
        }
    }
}
