using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;

    private enum WeaponHand
    {
        Left,
        Right
    }
    [SerializeField] private WeaponHand dominantHand;

    private void SwitchHand()
    {
        Transform hand = null;
        switch (dominantHand)
        {
            case WeaponHand.Left:
                hand = leftHand;
                break;

            case WeaponHand.Right:
                hand = rightHand;
                break;
        }

        //deactivate interactors
        hand.Find("Near-Far Interactor").gameObject.SetActive(false);

        //parent to hand & match hand's transform
        transform.SetParent(hand, false);
    }


    [SerializeField] private GameObject[] weapons;

    private void SwitchWeapon(int weaponID)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i != weaponID)
                weapons[i].SetActive(false);
            else
                weapons[weaponID].SetActive(true);
        }
    }

    private void Awake()
    {
        SwitchHand();
    }
}
