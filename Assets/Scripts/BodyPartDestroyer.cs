using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BodyPartDestroyer : MonoBehaviour
{
    private BoxCollider _collider;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _rigidbody = GetComponent<Rigidbody>();

        _collider.isTrigger = true;
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false;
    }
}
