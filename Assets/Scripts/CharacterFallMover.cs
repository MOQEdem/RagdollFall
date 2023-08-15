using UnityEngine;

public class CharacterFallMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private float _speed;

    [Header("RotationOptions")]
    [SerializeField] private bool _isNeedRotation;
    [SerializeField] private float _rotationSpeed;

    private void FixedUpdate()
    {
        if (_floatingJoystick.Direction != Vector2.zero)
        {
            _rigidbody.velocity += _floatingJoystick.DirectionVector3 * _speed * Time.fixedDeltaTime;
        }

        if (_isNeedRotation && Vector3.Dot(_rigidbody.transform.forward, Vector3.up) < 0.97)
        {
            var nextRotation = Quaternion.RotateTowards(_rigidbody.transform.rotation, Quaternion.Euler(-90, _rigidbody.transform.rotation.y, -90), _rotationSpeed);

            _rigidbody.MoveRotation(nextRotation);
        }
    }
}
