using System;
using System.Collections;
using UnityEngine;

public class CharacterBodyPartController : MonoBehaviour
{
    private CharacterBodyPart[] _characterBodyParts;
    private float _delay = 2f;
    private Coroutine _waitingDelay;

    public event Action<CharacterBodyPart, float> BodyPartDestroyed;

    private void Awake()
    {
        _characterBodyParts = GetComponentsInChildren<CharacterBodyPart>();
    }

    private void OnEnable()
    {
        for (int i = 0; i < _characterBodyParts.Length; i++)
        {
            _characterBodyParts[i].DestroyerTouched += OnBodyPartTouched;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _characterBodyParts.Length; i++)
        {
            _characterBodyParts[i].DestroyerTouched -= OnBodyPartTouched;
        }
    }

    private void OnBodyPartTouched(CharacterBodyPart bodyPart)
    {
        if (_waitingDelay == null)
        {
            bodyPart.DestroyerTouched -= OnBodyPartTouched;
            bodyPart.SetDestroyedStatus();

            BodyPartDestroyed?.Invoke(bodyPart, _delay);

            _waitingDelay = StartCoroutine(WaitingDelay());
        }
    }

    private IEnumerator WaitingDelay()
    {
        var delay = new WaitForSeconds(_delay);

        for (int i = 0; i < _characterBodyParts.Length; i++)
        {
            _characterBodyParts[i].SetReadyStatus(false);
        }

        yield return delay;

        for (int i = 0; i < _characterBodyParts.Length; i++)
        {
            _characterBodyParts[i].SetReadyStatus(true);
        }

        _waitingDelay = null;
    }
}
