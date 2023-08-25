using DG.Tweening;
using UnityEngine;

namespace _ProjectAssets.Scripts.UI
{
    public class ScaleHighlighter : MonoBehaviour
    {
        [SerializeField] private RectTransform _target;
        [SerializeField] private Vector2       _scaleVal;
        [SerializeField] private float         _duration;
        [SerializeField] private float         _interval;

        private Tween _scaleTween;

        private void OnEnable()
        {
            _scaleTween = DOTween.Sequence()
                   .Append(
                       _target
                           .DOScale(_scaleVal, _duration)
                           .SetEase(Ease.OutSine))
                   .SetLoops(-1, LoopType.Yoyo)
                   .SetRecyclable(true)
                   .OnKill(() => _scaleTween = null)
                   .Play();

            _scaleTween.SetDelay(_interval);
        }

        private void OnDisable()
        {
            _scaleTween.Kill();
        }
    }
}