using System;
using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
[RequireComponent(typeof(CharacterAnimator))]
[RequireComponent(typeof(CharacterPhysicsController))]
[RequireComponent(typeof(BoxCollider))]
public class CharacterStatusSwitcher : MonoBehaviour
{
    private CharacterMover _mover;
    private CharacterAnimator _animator;
    private CharacterPhysicsController _physicsController;
    private BoxCollider _collider;

    public Action FallingStarted;

    private void Awake()
    {
        _mover = GetComponent<CharacterMover>();
        _animator = GetComponent<CharacterAnimator>();
        _physicsController = GetComponent<CharacterPhysicsController>();
        _collider = GetComponent<BoxCollider>();

        _collider.isTrigger = true;

        // _physicsController.SetPhysicsStatus(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ActivatorOfFalling activator))
        {
            _mover.SetFallingStatus();
            _animator.OffAnimation();
            // _physicsController.SetPhysicsStatus(true);
            _collider.enabled = false;

            FallingStarted?.Invoke();
        }
    }
}
