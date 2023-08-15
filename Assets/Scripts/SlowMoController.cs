using System.Collections;
using UnityEngine;

public class SlowMoController : MonoBehaviour
{
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private AnimationCurve _animationCurve;

    private Coroutine _slowingTime;
    private float _normalFixedDeltaTimeScale = 0.02f;

    private void Awake()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }

    private void OnEnable()
    {
        _cameraController.DestroyedBodyPartShown += OnDestroyedBodyPartShown;
    }

    private void OnDisable()
    {
        _cameraController.DestroyedBodyPartShown -= OnDestroyedBodyPartShown;
    }

    private void OnDestroyedBodyPartShown(float timeToDelay)
    {
        if (_slowingTime == null)
            _slowingTime = StartCoroutine(SlowingTime(timeToDelay));
    }

    private IEnumerator SlowingTime(float timeToDelay)
    {
        for (float t = 0f; t < 1f; t += Time.deltaTime / timeToDelay)
        {
            float timeScale = _animationCurve.Evaluate(t);
            Time.timeScale = timeScale;
            Time.fixedDeltaTime = timeScale * _normalFixedDeltaTimeScale;

            yield return null;
        }

        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        _slowingTime = null;
    }
}
