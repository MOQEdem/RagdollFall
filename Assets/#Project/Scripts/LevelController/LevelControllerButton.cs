using UnityEngine;
using UnityEngine.UI;

public class LevelControllerButton : MonoBehaviour
{
    public Button Button { get; private set; }
    public CanvasGroup CanvasGroup { get; private set; }

    private void Awake()
    {
        Button = GetComponent<Button>();
        CanvasGroup = GetComponent<CanvasGroup>();
        CanvasGroup.alpha = 0;
    }

    public void SetInteractable(bool isInteractable)
    {
        CanvasGroup.interactable = isInteractable;
        CanvasGroup.blocksRaycasts = isInteractable;
    }
}
