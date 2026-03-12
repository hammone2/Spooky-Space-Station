using UnityEngine;
using System.Collections;

public class Airlock : MonoBehaviour
{
    [SerializeField] private Door door1;
    [SerializeField] private Door door2;
    private Door activeDoor;
    private bool canPressButton = true;

    private void Awake()
    {
        activeDoor = door1;
    }

    public void StartAirlockSequence()
    {
        if (canPressButton)
            StartCoroutine(AirlockSequence());
    }

    IEnumerator AirlockSequence()
    {
        activeDoor.Lock();
        canPressButton = false;

        yield return new WaitForSeconds(2f);

        if (activeDoor == door1)
            activeDoor = door2;
        else if (activeDoor == door2)
            activeDoor = door1;

        activeDoor.Unlock();
        canPressButton = true;
    }
}
