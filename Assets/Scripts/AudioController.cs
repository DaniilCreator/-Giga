using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider volumeSlider; // Ссылка на ползунок для управления громкостью общего звука
    public AudioSource audioSource; // Ссылка на аудиоисточник для общего звука

    public Slider musicVolumeSlider; // Ссылка на ползунок для управления громкостью музыки
    public AudioSource musicAudioSource; // Ссылка на аудиоисточник для музыки

    void Start()
    {
        // Устанавливаем начальное значение громкости для общего звука
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        audioSource.volume = volumeSlider.value;

        // Устанавливаем начальное значение громкости для музыки
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        musicAudioSource.volume = musicVolumeSlider.value;

        // Подписываемся на событие изменения значения ползунка для общего звука
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChanged(); });

        // Подписываемся на событие изменения значения ползунка для музыки
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChanged(); });
    }

    // Вызывается при изменении значения ползунка для общего звука
    void OnVolumeChanged()
    {
        audioSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }

    // Вызывается при изменении значения ползунка для музыки
    void OnMusicVolumeChanged()
    {
        musicAudioSource.volume = musicVolumeSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
    }
}
