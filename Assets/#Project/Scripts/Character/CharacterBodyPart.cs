using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CharacterBodyPart : MonoBehaviour
{
    [SerializeField] private BodyPartType _type;

    private bool _isDestroyed = false;
    private float _velocity = 3;
    private Rigidbody _rigidbody;

    public BodyPartType Type => _type;

    public event Action<CharacterBodyPart> DestroyerTouched;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isDestroyed)
            if (collision.relativeVelocity.magnitude > _velocity)
                DestroyerTouched?.Invoke(this);
    }

    public void SetPhysicality(bool isPhysical)
    {
        _rigidbody.isKinematic = !isPhysical;
        _rigidbody.useGravity = isPhysical;
    }

    public void SetRelativeVelocityNeededToDestroyPart(float velocity)
    {
        _velocity = velocity;
    }

    public void SetDestroyedStatus()
    {
        _isDestroyed = true;
    }
}

public enum BodyPartType
{
    LeftFoot,
    RightFoot,
    LeftThigh,
    RightThigh,
    LeftShoulder,
    RightShoulder,
    LeftHand,
    RightHand,
    Head,
    Pelvis,
    Chest
}
