using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private bool _hasSpaceSuit;
    public bool hasSpaceSuit
    {
        get
        {
            return _hasSpaceSuit;
        }

        set
        {
            _hasSpaceSuit = value;
            if (_hasSpaceSuit)
            {
                EquipSpaceSuit();
            }
            else
            {
                helmet.SetActive(false);
            }
        }
    }

    public bool spaceSuitEquipped;
    [SerializeField] private GameObject helmet;

    private void Awake()
    {
        Instance = this;
        hasSpaceSuit = spaceSuitEquipped;
    }

    private void EquipSpaceSuit()
    {
        Debug.Log("Spacesuit equipped!");
        helmet.SetActive(true);
    }
}
