using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CharacterBodyPart : MonoBehaviour
{
    private bool _readyToBeDestroyed = true;
    private bool _isDestroyed = false;
    private float _sqrVelocity = 8;

    public event Action<CharacterBodyPart> DestroyerTouched;

    private void OnCollisionEnter(Collision collision)
    {
        if (_readyToBeDestroyed && !_isDestroyed)
            if (collision.relativeVelocity.sqrMagnitude > _sqrVelocity)
                if (collision.rigidbody != null && collision.rigidbody.TryGetComponent(out BodyPartDestroyer destroyer))
                    DestroyerTouched?.Invoke(this);
    }

    public void SetRelativeVelocityNeededToDestroyPart(float velocity)
    {
        _sqrVelocity = velocity * velocity;
    }

    public void SetReadyStatus(bool isReady)
    {
        _readyToBeDestroyed = isReady;
    }

    public void SetDestroyedStatus()
    {
        _isDestroyed = true;
    }
}
