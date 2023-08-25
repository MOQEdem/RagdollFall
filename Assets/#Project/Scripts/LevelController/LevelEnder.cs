using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnder : MonoBehaviour
{
    [SerializeField] private Finisher _finisher;
    [SerializeField] private GameObject _finalRoulet;
    [SerializeField] private Button _noThanks;
    [SerializeField] private GameObject _tapToContinue;
    [SerializeField] private ParticleSystem _confettiParticle;
    [SerializeField] private EndButton _endButton;

    private LevelLoader _levelLoader;

    private void Awake()
    {
        _levelLoader = GetComponent<LevelLoader>();
    }

    private void OnEnable()
    {
        _finisher.LevelEnded += OnLevelEnded;
        _endButton.Button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _finisher.LevelEnded -= OnLevelEnded;
        _endButton.Button.onClick.RemoveListener(OnButtonClick);
    }

    private void Start()
    {
        _endButton.SetInteractable(false);
    }

    private void OnLevelEnded()
    {
        _confettiParticle.Play();
        _finalRoulet.SetActive(true);
        StartCoroutine(EndButtonInteractable());
    }

    private IEnumerator EndButtonInteractable()
    {
        yield return new WaitForSeconds(4f);
        _noThanks.gameObject.SetActive(true);
    }

    public void OnNoThanks()
    {
        _noThanks.gameObject.SetActive(false);
        _finalRoulet.SetActive(false);
        _tapToContinue.SetActive(true);
        _endButton.SetInteractable(true);
    }

    private void OnButtonClick()
    {
        _levelLoader.LoadNextLevel();
        _endButton.SetInteractable(false);
    }
}