using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private string levelName;

    public void SwitchLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
