using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LevelLoaderView : MonoBehaviour
{
    public static LevelLoaderView Instance { get; private set; }

    [SerializeField] private Image _bar;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _startSound;

    private Coroutine _loadingCoroutine;
    private bool _isLoading = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        _startSound.Play();
    }

    public void ShowLoadingProgress(AsyncOperation asyncOperation)
    {
        if (_loadingCoroutine == null)
        {
            _loadingCoroutine = StartCoroutine(LoadingScene(asyncOperation));
            _isLoading = true;
        }
    }

    public void HideLoadingProgress()
    {
        _isLoading = false;
    }

    private IEnumerator LoadingScene(AsyncOperation asyncOperation)
    {
        float speed = 1f;

        Tween tween;

        if (_canvasGroup.alpha != 1)
        {
            tween = _canvasGroup.DOFade(1f, 0.2f);

            yield return tween.WaitForCompletion();
        }

        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

        while (_isLoading || _bar.fillAmount <= 0.99f)
        {
            float progress = asyncOperation.progress / 0.9f;

            _bar.fillAmount = Mathf.MoveTowards(_bar.fillAmount, progress, speed * Time.deltaTime);
            yield return null;
        }

        _bar.fillAmount = 1f;

        tween = _canvasGroup.DOFade(0f, 1f);

        yield return tween.WaitForCompletion();

        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;

        _bar.fillAmount = 0;

        while (_startSound.isPlaying)
            yield return null;

        if (!_music.isPlaying)
        {
            _music.Play();
        }

        _loadingCoroutine = null;
    }
}

