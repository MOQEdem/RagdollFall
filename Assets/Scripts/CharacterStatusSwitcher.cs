using System;
using UnityEngine;

[RequireComponent(typeof(CharacterWalkMover))]
[RequireComponent(typeof(CharacterFallMover))]
[RequireComponent(typeof(CharacterAnimator))]
[RequireComponent(typeof(CharacterPhysicsController))]
[RequireComponent(typeof(BoxCollider))]
public class CharacterStatusSwitcher : MonoBehaviour
{
    private CharacterWalkMover _walkMover;
    private CharacterFallMover _fallMover;
    private CharacterAnimator _animator;
    private CharacterPhysicsController _physicsController;
    private BoxCollider _collider;

    public Action FallingStarted;

    private void Awake()
    {
        _walkMover = GetComponent<CharacterWalkMover>();
        _fallMover = GetComponent<CharacterFallMover>();
        _animator = GetComponent<CharacterAnimator>();
        _physicsController = GetComponent<CharacterPhysicsController>();
        _collider = GetComponent<BoxCollider>();

        _walkMover.enabled = true;
        _fallMover.enabled = false;
        _collider.isTrigger = true;

        _physicsController.SetPhysicsStatus(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ActivatorOfFalling activator))
        {
            _walkMover.enabled = false;
            _fallMover.enabled = true;
            _animator.OffAnimation();
            _physicsController.SetPhysicsStatus(true);
            _collider.enabled = false;

            FallingStarted?.Invoke();
        }
    }
}
