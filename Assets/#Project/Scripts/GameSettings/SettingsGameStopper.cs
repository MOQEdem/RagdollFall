using UnityEngine;

public class SettingsGameStopper : MonoBehaviour
{
    public void SetGameSpeed(bool inPlaying)
    {
        Time.timeScale = inPlaying ? 1f : 0.025f;
    }
}
