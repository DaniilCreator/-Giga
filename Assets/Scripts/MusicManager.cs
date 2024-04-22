using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip musicClip; // Аудиоклип музыки
    private AudioSource musicSource; // Ссылка на AudioSource

    void Start()
    {
        // Получаем компонент AudioSource, присоединенный к этому объекту или создаем новый, если его нет
        musicSource = GetComponent<AudioSource>();
        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
        }

        // Устанавливаем аудиоклип музыки
        musicSource.clip = musicClip;

        // Устанавливаем зацикленное воспроизведение музыки
        musicSource.loop = true;

        // Начинаем воспроизведение музыки
        musicSource.Play();
    }
}
