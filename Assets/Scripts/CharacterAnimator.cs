using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator;

    private const string Run = nameof(Run);

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void SetRunningStatus(bool isRunning)
    {
        _animator.SetBool(Run, isRunning);
    }

    public void OffAnimation()
    {
        _animator.enabled = false;
    }
}
