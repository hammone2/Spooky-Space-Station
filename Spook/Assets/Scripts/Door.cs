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
    [SerializeField] private float yStart;
    [SerializeField] private float yEnd;


    private void Awake()
    {
        _renderer = doorObject.GetComponent<Renderer>();
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

        Close();
        SwitchState(DoorStates.Locked);
    }

    public void Open()
    {
        if (doorState != DoorStates.Unlocked)
            return;

        //animation + other stuff

        //this is temporary
        doorObject.transform.localPosition = new Vector3(doorObject.transform.localPosition.x, yEnd, doorObject.transform.localPosition.z);
    }

    public void Close()
    {
        if (doorState != DoorStates.Unlocked)
            return;

        //animation + other stuff

        //this is temporary
        doorObject.transform.localPosition = new Vector3(doorObject.transform.localPosition.x, yStart, doorObject.transform.localPosition.z);
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
