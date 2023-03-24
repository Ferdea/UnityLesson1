using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Transform _playerTransform;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var difference = _playerTransform.position - transform.position;
        difference.z = 0;
        var movement = (_speed * Time.deltaTime > difference.magnitude ? difference.magnitude : _speed * Time.deltaTime) 
            * difference.normalized;
        _rb.MovePosition(transform.position + movement);
    }
}
