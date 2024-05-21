using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevelButton : MonoBehaviour
{
    public void FinalButton()
    {
        PlayerPrefs.SetInt("CurrentScene", 0);
        SceneManager.LoadScene(0);
    }
}
