using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _endPosX;
    [SerializeField] private float _startPosX;
    private Vector3 _moveVector;

    private void FixedUpdate()
    {
        _moveVector = _playerTransform.position - transform.position;

        if (transform.position.x < _endPosX && _moveVector.x > _startPosX)
        {
            transform.position += new Vector3(_moveVector.x, 0f, 0f);
        }
    }
}
