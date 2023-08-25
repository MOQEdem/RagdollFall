using DG.Tweening;
using UnityEngine;

namespace _ProjectAssets.Scripts.UI
{
    public class Finger : MonoBehaviour
    {
        [SerializeField] private RectTransform _finger;
        [SerializeField] private Vector2       _minPos;
        [SerializeField] private Vector2       _maxPos;
        [SerializeField] private float         _moveDuration;

        private Tweener _moveTweener;

        private void OnEnable()
        {
            _moveTweener =
                _finger
                    .DOAnchorPos(_maxPos, _moveDuration)
                    .From(_minPos)
                    .SetEase(Ease.InOutCubic)
                    .SetLoops(-1, LoopType.Yoyo)
                    .SetRecyclable(true)
                    .OnKill(() => _moveTweener = null)
                    .Play();
        }

        private void OnDisable()
        {
            _moveTweener.Kill();
        }
    }
}