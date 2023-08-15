using System;
using UnityEngine;

public class CharacterStatusSwitcher : MonoBehaviour
{
    [SerializeField] private CharacterWalkMover _walkMover;
    [SerializeField] private CharacterFallMover _fallMover;
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private CharacterBodyPartController _physicsController;
    [SerializeField] private Collider _collider;

    public Action FallingStarted;

    private void Awake()
    {
        _walkMover.enabled = true;
        _fallMover.enabled = false;
        _collider.isTrigger = true;
    }

    private void FixedUpdate()
    {
        if (!Physics.Raycast(transform.position, -transform.up, 1))
        {
            SetaFallStatus();

            this.enabled = false;
        }
    }

    private void SetaFallStatus()
    {
        _walkMover.enabled = false;
        _fallMover.enabled = true;
        _animator.OffAnimation();
        _physicsController.MakePhysical();
        _collider.enabled = false;

        FallingStarted?.Invoke();
    }
}
