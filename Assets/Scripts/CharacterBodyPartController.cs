using System;
using System.Collections;
using UnityEngine;

public class CharacterBodyPartController : MonoBehaviour
{
    [SerializeField][Range(0, 20)] private float _velocityToDestroyPart;
    [SerializeField] private float _delayBetweenDestroyability = 2f;

    private Rigidbody[] _rigidbodies;
    private CharacterBodyPart[] _characterBodyParts;
    private Coroutine _waitingDelay;

    public event Action<CharacterBodyPart, float> BodyPartDestroyed;

    private void Awake()
    {
        _characterBodyParts = GetComponentsInChildren<CharacterBodyPart>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();

        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = true;
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < _characterBodyParts.Length; i++)
        {
            _characterBodyParts[i].DestroyerTouched += OnBodyPartTouched;
            _characterBodyParts[i].SetRelativeVelocityNeededToDestroyPart(_velocityToDestroyPart);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _characterBodyParts.Length; i++)
        {
            _characterBodyParts[i].DestroyerTouched -= OnBodyPartTouched;
        }
    }

    public void MakePhysical()
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = false;
        }
    }

    private void OnBodyPartTouched(CharacterBodyPart bodyPart)
    {
        if (_waitingDelay == null)
        {
            bodyPart.DestroyerTouched -= OnBodyPartTouched;
            bodyPart.SetDestroyedStatus();

            BodyPartDestroyed?.Invoke(bodyPart, _delayBetweenDestroyability);

            _waitingDelay = StartCoroutine(WaitingDelay());
        }
    }

    private IEnumerator WaitingDelay()
    {
        var delay = new WaitForSeconds(_delayBetweenDestroyability);

        yield return delay;

        _waitingDelay = null;
    }
}
