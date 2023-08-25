using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int _currentLevel = 1;
    private Coroutine _loadCoroutine;

    private const float DonePercent = 0.9f;

    public void LoadStartLevel()
    {
        if (_loadCoroutine == null)
            _loadCoroutine = StartCoroutine(LoadScene(true));
    }

    public void LoadNextLevel()
    {
        _currentLevel++;

        if (_loadCoroutine == null)
            _loadCoroutine = StartCoroutine(LoadScene(false));
    }

    private IEnumerator LoadScene(bool isStartLoad)
    {
        if (isStartLoad)
            yield return new WaitForSeconds(1f);

        yield return new WaitForEndOfFrame();

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;

        LevelLoaderView.Instance.ShowLoadingProgress(asyncOperation);

        while (asyncOperation.progress < DonePercent)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1.5f);

        LevelLoaderView.Instance.HideLoadingProgress();

        asyncOperation.allowSceneActivation = true;

        _loadCoroutine = null;
    }
}
