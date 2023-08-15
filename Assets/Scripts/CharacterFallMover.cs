using UnityEngine;

public class CharacterFallMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        if (_floatingJoystick.Direction != Vector2.zero)
        {
            _rigidbody.velocity += _floatingJoystick.DirectionVector3 * _speed * Time.fixedDeltaTime;
        }
    }
}
