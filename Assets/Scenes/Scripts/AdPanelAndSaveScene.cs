using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdManagerAndSaveScene : MonoBehaviour
{
    [SerializeField] private GameObject _adPanel;
    private static float _adCooldown = 65f;
    private static float _adCooldownTimer = 0f;
    [SerializeField] private bool _canSave = true;

    private void Awake()
    {
        if (_canSave)
            PlayerPrefs.SetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
    }

    //private void FixedUpdate()
    //{
    //    _adCooldownTimer += Time.fixedDeltaTime;

    //    if (_adCooldownTimer > _adCooldown)
    //        StartCoroutine(AdPanel());
    //}

    //private IEnumerator AdPanel()
    //{
    //    _adCooldownTimer = 0f;
    //    _adPanel.SetActive(true);
    //    WaveController.SpeedScale = 0f;
    //    yield return new WaitForSeconds(3f);
    //    WaveController.SpeedScale = 1f;
    //    YG.YandexGame.FullscreenShow();
    //    _adPanel.SetActive(false);
    //}
}
