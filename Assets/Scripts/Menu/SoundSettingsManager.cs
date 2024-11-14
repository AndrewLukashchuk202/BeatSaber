using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettingsManager : MonoBehaviour
{
    [SerializeField] private Scrollbar masterVolumeSlider;
    [SerializeField] private Scrollbar musicVolumeSlider;
    [SerializeField] private Scrollbar effectsVolumeSlider;
    [SerializeField] private AudioMixer audioMixer;
    void Start()
    {
        if (!audioMixer)
        {
            Debug.Log($"SoundManager-> AudioMixer has not been assigned.");
            return;
        }
        
        // Add Listeners for scroll events.
        if (masterVolumeSlider == null) masterVolumeSlider.onValueChanged.AddListener(SetMasterVolumeLevel);
        if (musicVolumeSlider == null) musicVolumeSlider.onValueChanged.AddListener(SetEffectsVolumeLevel);
        if (effectsVolumeSlider == null) effectsVolumeSlider.onValueChanged.AddListener(SetMusicVolumeLevel);
        
        // Set defaults for pref keys.
        if (!PlayerPrefs.HasKey("MasterVolume"))
        {
            PlayerPrefs.SetFloat("MasterVolume", 0.75f);
        }
        
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 0.75f);
        }
        
        if (!PlayerPrefs.HasKey("EffectsVolume"))
        {
            PlayerPrefs.SetFloat("EffectsVolume", 0.75f);
        }
    }
    
    private void SetMasterVolumeLevel(float sliderValue)
    {
        if (masterVolumeSlider == null || audioMixer == null) return;
        
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat("MasterVolume", 0.75f)) * 20);
    }

    private void SetEffectsVolumeLevel(float sliderValue)
    {
        if (musicVolumeSlider == null || audioMixer == null) return;
        
        PlayerPrefs.SetFloat("EffectsVolume", sliderValue);
        audioMixer.SetFloat("EffectsVolume", Mathf.Log10(PlayerPrefs.GetFloat("EffectsVolume", 0.75f)) * 20);
    }

    private void SetMusicVolumeLevel(float sliderValue)
    {
        if (effectsVolumeSlider == null || audioMixer == null) return;
        
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 0.75f)) * 20);
    }
}
