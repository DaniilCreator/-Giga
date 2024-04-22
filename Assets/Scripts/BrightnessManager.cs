using UnityEngine;
using UnityEngine.UI;

public class BrightnessManager : MonoBehaviour
{
    public Slider brightnessSlider; // Ссылка на Slider в вашем интерфейсе
    public SpriteRenderer[] spritesToAdjust; // Массив спрайтов, которые нужно настроить

    void Start()
    {
        // Устанавливаем начальное значение Slider в середину диапазона
        float middleValue = 0.5f; // Значение посередине
        brightnessSlider.value = middleValue;

        // Загружаем предыдущее значение яркости или устанавливаем по умолчанию
        float savedBrightness = PlayerPrefs.GetFloat("Brightness", middleValue);
        SetBrightness(savedBrightness);

        // Добавляем обработчик события OnValueChanged к Slider
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
    }

    // Метод для изменения яркости при перемещении ползунка
    public void SetBrightness(float brightness)
    {
        foreach (SpriteRenderer spriteRenderer in spritesToAdjust)
        {
            // Получаем текущий цвет спрайта
            Color color = spriteRenderer.color;

            // Устанавливаем новое значение яркости для цвета спрайта
            color.a = brightness;

            // Устанавливаем новый цвет спрайта с измененной яркостью
            spriteRenderer.color = color;
        }

        // Сохраняем настройку яркости
        PlayerPrefs.SetFloat("Brightness", brightness);
        PlayerPrefs.Save();
    }
}
