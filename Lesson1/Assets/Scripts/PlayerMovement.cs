using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        var directionX = Input.GetAxisRaw("Horizontal");
        var directionY = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(directionX, directionY, 0);

        _rb.MovePosition(transform.position + _speed * Time.deltaTime * direction.normalized);
        if (direction.magnitude >= 1e-9)
        {
            var angleDifference = Mathf.DeltaAngle(_rb.rotation, Mathf.Atan2(directionY, directionX) * Mathf.Rad2Deg - 90);
            var angleToRotate = Mathf.Min(_rotationSpeed * Time.deltaTime, Mathf.Abs(angleDifference)) * Mathf.Sign(angleDifference);
            _rb.MoveRotation(_rb.rotation + angleToRotate);
        } 
    }
}
