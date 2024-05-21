using UnityEngine;
using UnityEngine.SceneManagement;

public class GetCurrentScene : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("CurrentScene") != 0)
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentScene"));
        }
    }
}
