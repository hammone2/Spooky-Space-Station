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

    private Renderer _renderer; //replace this later with light object ref
    [SerializeField] private GameObject doorObject; //temporary
    [SerializeField] private Material greenLight;
    [SerializeField] private Material yellowLight;
    [SerializeField] private Material redLight;

    //temporary
    private float yStart;
    private float yEnd;


    private void Awake()
    {
        _renderer = doorObject.GetComponent<Renderer>();
        SwitchState(doorState);
        yStart = doorObject.transform.position.y;
        yEnd = yStart + 2.5f; //temporary
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

        //this is temporary
        doorObject.transform.position = new Vector3(doorObject.transform.position.x, yEnd, doorObject.transform.position.z);
    }

    public void Close()
    {
        if (doorState != DoorStates.Unlocked)
            return;

        //animation + other stuff

        //this is temporary
        doorObject.transform.position = new Vector3(doorObject.transform.position.x, yStart, doorObject.transform.position.z);
    }

    private void SwitchState(DoorStates newState)
    {
        doorState = newState;
        switch (doorState)
        {
            case DoorStates.Unlocked:
                _renderer.material = greenLight;
                break;

            case DoorStates.Locked:
                _renderer.material = yellowLight;
                break;

            case DoorStates.Inaccessible:
                _renderer.material = redLight;
                break;
        }
    }

    private void OnValidate() //make it so I can see the door color in the scene view
    {
        if (!_renderer)
            _renderer = doorObject.GetComponent<Renderer>();

        SwitchState(doorState);
    }
}
