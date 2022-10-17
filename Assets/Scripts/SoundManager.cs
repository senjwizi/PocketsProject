using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundManager : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    public TMP_Text volumeText;

    private void Start()
    {
        DontDestroyOnLoad(this);
        UpdateVolume();
    }

    public void OnSliderChanged(float value)
    { 
        audioSource.volume = value;
        volumeText.text = "Звук: " + (value * 100f).ToString("0") + "%";
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", audioSource.volume);
    }

    public void UpdateVolume()
    {
        float volume = PlayerPrefs.GetFloat("MusicVolume");
        audioSource.volume = volume;
        volumeSlider.value = volume;
        volumeText.text = "Звук: " + (volume * 100f).ToString("0") + "%";
    }
}
