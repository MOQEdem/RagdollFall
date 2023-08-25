using Cinemachine;
using System;
using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private CharacterStatusSwitcher _switcher;
    [SerializeField] private CharacterBodyPartController _bodyPartController;
    [Space]
    [Header("Cameras")]
    [SerializeField] private CinemachineBrain _mainCamera;
    [SerializeField] private CinemachineVirtualCamera _walkCamera;
    [SerializeField] private CinemachineVirtualCamera _fallCamera;
    [SerializeField] private CinemachineVirtualCamera _bodyPartCamera;

    private Coroutine _waitingDelay;

    public event Action<float> DestroyedBodyPartShown;

    private void Awake()
    {
        _walkCamera.Priority = 1;
        _fallCamera.Priority = 0;
        _bodyPartCamera.Priority = 0;
        _mainCamera.m_UpdateMethod = CinemachineBrain.UpdateMethod.LateUpdate;
        _mainCamera.m_BlendUpdateMethod = CinemachineBrain.BrainUpdateMethod.LateUpdate;
    }

    private void OnEnable()
    {
        _switcher.FallingStarted += SwitchToFallCamera;
        _bodyPartController.BodyPartDestroyed += OnBodyPartDestroyed;
    }

    private void OnDisable()
    {
        _switcher.FallingStarted -= SwitchToFallCamera;
        _bodyPartController.BodyPartDestroyed -= OnBodyPartDestroyed;
    }

    private void SwitchToFallCamera()
    {
        _switcher.FallingStarted -= SwitchToFallCamera;

        _mainCamera.m_UpdateMethod = CinemachineBrain.UpdateMethod.FixedUpdate;
        _mainCamera.m_BlendUpdateMethod = CinemachineBrain.BrainUpdateMethod.FixedUpdate;

        _walkCamera.Priority = 0;
        _fallCamera.Priority = 1;
    }

    private void OnBodyPartDestroyed(CharacterBodyPart bodyPart, float timeToDelay)
    {
        _bodyPartCamera.Follow = bodyPart.transform;
        _bodyPartCamera.LookAt = bodyPart.transform;

        if (_waitingDelay == null)
        {
            DestroyedBodyPartShown?.Invoke(timeToDelay);
            _waitingDelay = StartCoroutine(WaitingDelay(timeToDelay));
        }
    }

    private IEnumerator WaitingDelay(float timeToDelay)
    {
        var delay = new WaitForSeconds(timeToDelay);

        _fallCamera.Priority = 0;
        _bodyPartCamera.Priority = 1;

        yield return delay;

        _fallCamera.Priority = 1;
        _bodyPartCamera.Priority = 0;

        _waitingDelay = null;
    }
}
