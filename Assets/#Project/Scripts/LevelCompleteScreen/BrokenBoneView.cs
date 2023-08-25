using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BrokenBoneView : MonoBehaviour
{
    [SerializeField] private BodyPartType _type;
    [SerializeField] private Color _flashingColor;

    private float _flashingTime;
    private Color _baseColor;
    private Coroutine _flashing;
    private Image _boneImage;

    public BodyPartType Type => _type;

    private void Awake()
    {
        _boneImage = GetComponent<Image>();
        _baseColor = _boneImage.color;
    }

    public void StartFlashing(float flashingTime)
    {
        _flashingTime = flashingTime;

        if (_flashing == null)
            _flashing = StartCoroutine(Flashing());
    }

    private IEnumerator Flashing()
    {
        yield return null;

        while (_flashing != null)
        {
            Tween tween = _boneImage.DOColor(_flashingColor, _flashingTime);

            yield return tween.WaitForCompletion();

            tween = _boneImage.DOColor(_baseColor, _flashingTime);

            yield return tween.WaitForCompletion();
        }

        _flashing = null;
    }
}
