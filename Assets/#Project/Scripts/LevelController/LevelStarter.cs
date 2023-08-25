using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private StartButton _startButton;

    private void Awake()
    {

    }

    private void OnEnable()
    {
        // _startButton.Button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        // _startButton.Button.onClick.RemoveListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        _startButton.SetInteractable(false);
    }
}