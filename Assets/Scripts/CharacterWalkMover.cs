using UnityEngine;

[RequireComponent(typeof(CharacterAnimator))]
public class CharacterWalkMover : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private float _speed;

    private CharacterAnimator _animator;

    private void Start()
    {
        _animator = GetComponent<CharacterAnimator>();
    }

    private void Update()
    {
        if (_floatingJoystick.Direction != Vector2.zero)
        {
            _animator.SetRunningStatus(true);

            transform.rotation = Quaternion.LookRotation(_floatingJoystick.DirectionVector3, Vector3.up);
            transform.position += _floatingJoystick.DirectionVector3 * _speed * Time.deltaTime;
        }
        else
        {
            _animator.SetRunningStatus(false);
        }
    }
}
