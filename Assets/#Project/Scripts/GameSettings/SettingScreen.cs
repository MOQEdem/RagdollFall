using UnityEngine;
using UnityEngine.UI;

public class SettingScreen : MonoBehaviour
{
    private const string IsSoundON = nameof(IsSoundON);
    private const string IsMusicON = nameof(IsMusicON);

    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _soundToggle;

    private AudioSettings _audioSettings;

    private void Awake()
    {
        _audioSettings = GetComponent<AudioSettings>();
    }

    private void OnEnable()
    {
        _musicToggle.onValueChanged.AddListener(OnMusicToggleChanged);
        _soundToggle.onValueChanged.AddListener(OnSoundToggleChanged);
    }

    private void OnDisable()
    {
        _musicToggle.onValueChanged.RemoveListener(OnMusicToggleChanged);
        _soundToggle.onValueChanged.RemoveListener(OnSoundToggleChanged);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(IsMusicON))
        {
            if (PlayerPrefs.GetInt(IsMusicON) == 0)
                OnMusicToggleChanged(false);
            else
                OnMusicToggleChanged(true);
        }
        else
            OnMusicToggleChanged(true);


        if (PlayerPrefs.HasKey(IsSoundON))
        {
            if (PlayerPrefs.GetInt(IsSoundON) == 0)
                OnSoundToggleChanged(false);
            else
                OnSoundToggleChanged(true);
        }
        else
            OnSoundToggleChanged(true);
    }

    private void OnSoundToggleChanged(bool state)
    {
        _soundToggle.isOn = state;

        if (state)
            _audioSettings.UnmuteAudioGroup(AudioGroup.SFX);
        else
            _audioSettings.MuteAudioGroup(AudioGroup.SFX);

        PlayerPrefs.SetInt(IsSoundON, state ? 1 : 0);
    }

    private void OnMusicToggleChanged(bool state)
    {
        _musicToggle.isOn = state;

        if (state)
            _audioSettings.UnmuteAudioGroup(AudioGroup.Music);
        else
            _audioSettings.MuteAudioGroup(AudioGroup.Music);

        PlayerPrefs.SetInt(IsMusicON, state ? 1 : 0);
    }

    public void OnOffAllSounds(bool isAble)
    {
        if (isAble)
            _audioSettings.UnmuteAudioGroup(AudioGroup.Master);
        else
            _audioSettings.MuteAudioGroup(AudioGroup.Master);
    }
}