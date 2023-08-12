using UnityEngine;

public class CharacterPhysicsController : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;

    public void SetPhysicsStatus(bool isPhysical)
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = !isPhysical;
        }

    }
}
