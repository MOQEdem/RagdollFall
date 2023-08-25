using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeightScale : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private CharacterStatusSwitcher _statusSwitcher;
    [SerializeField] private CharacterBodyPart _player;
    [SerializeField] private Finisher _finisher;
    [SerializeField] private TMP_Text _height;
    [Space]
    [Header("Colors")]
    [SerializeField] private Image _fillArea;
    [SerializeField] private Color _blueColor;
    [SerializeField] private Color _redColor;

    private Slider _scale;
    private Coroutine _scaling;
    private float _colorChangeHeight;
    private float _percentageForColorChange = 0.8f;
    private string _postFix = "m";

    private void Awake()
    {
        _scale = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _statusSwitcher.FallingStarted += OnFallingStarted;
    }

    private void OnDisable()
    {
        _statusSwitcher.FallingStarted -= OnFallingStarted;
    }

    private void Start()
    {
        _scale.minValue = _finisher.transform.position.y;
        _scale.value = _scale.minValue;
        _scale.maxValue = _player.transform.position.y;

        _colorChangeHeight = (_scale.maxValue - _scale.minValue) * _percentageForColorChange;

        _height.text = _player.transform.position.y.ToString("0") + _postFix;

        _fillArea.color = _blueColor;
    }

    private void OnFallingStarted()
    {
        if (_scaling == null)
            _scaling = StartCoroutine(Scaling());
    }

    private IEnumerator Scaling()
    {
        float offset = 0.5f;

        while (_scale.value <= _scale.maxValue - offset)
        {
            _scale.value = _scale.maxValue - _player.transform.position.y;
            _height.text = _player.transform.position.y.ToString("0") + _postFix;

            if (_scale.value >= _colorChangeHeight && _fillArea.color != _redColor)
                _fillArea.color = _redColor;

            yield return null;
        }

        _scale.value = _scale.maxValue;
        _height.text = "0" + _postFix;
    }

}
