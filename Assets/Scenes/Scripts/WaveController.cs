using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _sceneIndex;
    private float _currentSpeedX;
    private float _currentSpeedY;
    static public float SpeedScale;
    [SerializeField] private GameObject _pacticle;

    [Header("SFX")]
    [SerializeField] private AudioClip _win;
    [SerializeField] private AudioClip _die;

    private void Awake()
    {
        SpeedScale = 1f;
        _currentSpeedX = _speed / 30f;
        _currentSpeedY = _speed / 30f;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position += new Vector3(_currentSpeedX * SpeedScale, _currentSpeedY * SpeedScale, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -45), 0.3f);
        }
        else
        {
            transform.position += new Vector3(_currentSpeedX * SpeedScale, -_currentSpeedY * SpeedScale, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -135), 0.3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
            StartCoroutine(Win());
        else if (collision.tag == "Ground")
            StartCoroutine(Die());
    }

    private IEnumerator Win()
    {
        SoundManager.Instance.PlaySound(_win);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        _pacticle.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        SpeedScale = 0f;
        yield return new WaitForSeconds(1f);
        SpeedScale = 1f;
        SceneManager.LoadScene(_sceneIndex);
    }

    private IEnumerator Die()
    {
        SoundManager.Instance.PlaySound(_die);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        _pacticle.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        SpeedScale = 0f;
        yield return new WaitForSeconds(1f);
        SpeedScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
