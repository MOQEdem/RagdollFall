using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CharacterBodyPart : MonoBehaviour
{
    private bool _isDestroyed = false;
    private float _velocity = 3;

    public event Action<CharacterBodyPart> DestroyerTouched;

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isDestroyed)
            if (collision.relativeVelocity.magnitude > _velocity)
                DestroyerTouched?.Invoke(this);
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
