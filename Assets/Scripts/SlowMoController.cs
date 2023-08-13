using System.Collections;
using UnityEngine;

public class SlowMoController : MonoBehaviour
{
    [SerializeField] private CameraController _cameraController;

    private Coroutine _slowingTime;

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
        var quarterOfDelay = timeToDelay / 4;

        var timeToSlowDone = quarterOfDelay;

        while (timeToSlowDone > 0)
        {
            timeToSlowDone -= Time.deltaTime;

            if (Time.timeScale >= 0.5)
                Time.timeScale -= Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(quarterOfDelay * 2);

        var timeToSpeedUp = quarterOfDelay;

        while (timeToSpeedUp > 0)
        {
            timeToSpeedUp -= Time.deltaTime;

            if (Time.timeScale < 1)
                Time.timeScale += Time.deltaTime;

            yield return null;
        }

        Time.timeScale = 1;
        _slowingTime = null;
    }
}