using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CharacterBodyPart : MonoBehaviour
{
    private bool _readyToBeDestroyed = true;
    private bool _isDestroyed = false;

    public event Action<CharacterBodyPart> DestroyerTouched;

    private void OnCollisionEnter(Collision collision)
    {
        if (_readyToBeDestroyed && !_isDestroyed)
            if (collision.relativeVelocity.sqrMagnitude > 8)
                if (collision.rigidbody != null && collision.rigidbody.TryGetComponent(out BodyPartDestroyer destroyer))
                    DestroyerTouched?.Invoke(this);
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
