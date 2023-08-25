using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private Button[] _otherButtons;
    [SerializeField] private GameObject _tutorial;

    private void Awake()
    {
        foreach (var button in _otherButtons)
            button.enabled = false;
    }

    private void OnClearPowerChanged(float value)
    {
        //if (_playerAttributes.ClearLevel > 2)
        //{
        //    _playerAttributes.ClearPowerChanged -= OnClearPowerChanged;

        //    foreach (var button in _otherButtons)
        //        button.enabled = true;

        //    Destroy(_tutorial);
        //}
    }
}
