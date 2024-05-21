using UnityEngine;

public class StartPanel : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("CurrentScene") == 0)
            Time.timeScale = 0.01f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
