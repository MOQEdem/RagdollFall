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
            transform.rotation = Quaternion.LookRotation(new Vector3(_floatingJoystick.Direction.x, 0f, _floatingJoystick.Direction.y), Vector3.up);
            transform.position += new Vector3(_floatingJoystick.Direction.x, 0f, _floatingJoystick.Direction.y) * _speed * Time.deltaTime;
        }
        else
        {
            _animator.SetRunningStatus(false);
        }
    }
}
