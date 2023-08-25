using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    private const float LowSoundValue = -80;
    private const float HighSoundValue = 0;

    public void MuteAudioGroup(AudioGroup audioGroup)
    {
        _mixer.SetFloat(GetAudioGroupName(audioGroup), LowSoundValue);
    }

    public void UnmuteAudioGroup(AudioGroup audioGroup)
    {
        _mixer.SetFloat(GetAudioGroupName(audioGroup), HighSoundValue);
    }

    public string GetAudioGroupName(AudioGroup audioGroup)
    {
        switch (audioGroup)
        {
            case AudioGroup.Master:
                return AudioGroupName.Master;
            case AudioGroup.SFX:
                return AudioGroupName.SFX;
            case AudioGroup.Music:
                return AudioGroupName.Music;
            default:
                return null;
        }
    }

    public class AudioGroupName
    {
        public const string Master = nameof(Master);
        public const string SFX = nameof(SFX);
        public const string Music = nameof(Music);
    }

}

public enum AudioGroup
{
    Master,
    SFX,
    Music
}
