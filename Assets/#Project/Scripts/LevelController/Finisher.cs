using System;
using UnityEngine;

public class Finisher : MonoBehaviour
{
    public event Action LevelEnded;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out CharacterBodyPart bodyPart))
        {
            LevelEnded?.Invoke();
            this.enabled = false;
        }
    }
}
