using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelCompleteScreen : MonoBehaviour
{
    [SerializeField] private Finisher _finisher;
    [SerializeField] private CharacterBodyPartController _bodyPartController;
    [SerializeField] private BrokenBoneCounter _brokenBoneCounter;
    [SerializeField] private BrokenBoneView[] _brokenBoneViews;
    [SerializeField] private float _flashingTime = 0.75f;
    [SerializeField] private CanvasGroup _canvasGroup;

    private float _showingTime = 0.5f;

    private List<BodyPartType> _brokenTypes = new List<BodyPartType>();

    private void Awake()
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    private void OnEnable()
    {
        _bodyPartController.BodyPartDestroyed += OnBodyPartDestroyed;
        _finisher.LevelEnded += ShowScreen;
    }

    private void OnDisable()
    {
        _bodyPartController.BodyPartDestroyed -= OnBodyPartDestroyed;
        _finisher.LevelEnded -= ShowScreen;
    }

    private void ShowScreen()
    {
        _finisher.LevelEnded -= ShowScreen;

        _canvasGroup.DOFade(1f, _showingTime);
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

        ShowLevelStatistic();
    }

    private void OnBodyPartDestroyed(CharacterBodyPart bodyPart, float delayTime)
    {
        _brokenTypes.Add(bodyPart.Type);
    }

    private void ShowLevelStatistic()
    {
        foreach (var type in _brokenTypes)
            foreach (var view in _brokenBoneViews)
                if (view.Type == type)
                    view.StartFlashing(_flashingTime);

        _brokenBoneCounter.SetCounterValues(_brokenTypes);
    }
}
