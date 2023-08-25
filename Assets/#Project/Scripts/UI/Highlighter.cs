using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _ProjectAssets.Scripts.UI
{
    public class Highlighter : MonoBehaviour
    {
        [SerializeField] private Image _highlighter;

        [SerializeField] private Vector2 _startPos;
        [SerializeField] private Vector2 _endPos;
        [SerializeField] private float   _highlightDuration;
        [SerializeField] private float   _delay;

        private Tween _highlightTween;

        private void OnEnable()
        {
            _highlightTween =
                DOTween
                    .Sequence()
                    .AppendInterval(_delay)
                    .AppendCallback(() => _highlighter.enabled = true)
                    .Append(
                        _highlighter
                            .rectTransform
                            .DOAnchorPos(_endPos, _highlightDuration)
                            .From(_startPos)
                            .SetEase(Ease.OutQuart)
                    )
                    .AppendCallback(() => _highlighter.enabled = false)
                    .SetLoops(-1)
                    .SetRecyclable(true)
                    .OnKill(() => _highlightTween = null);
        }

        private void OnDisable()
        {
            _highlightTween.Kill();
        }
    }
}