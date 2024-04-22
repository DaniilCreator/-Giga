using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResolutionManager : MonoBehaviour
{
    public Dropdown resolutionDropdown; // Публичная переменная для Dropdown

    private Resolution[] resolutions;

    void Start()
    {
        // Получаем доступ ко всем доступным разрешениям экрана.
        resolutions = Screen.resolutions;
        // Очищаем список вариантов разрешений в выпадающем меню.
        resolutionDropdown.ClearOptions();
        // Создаем список строк для хранения вариантов разрешений.
        List<string> options = new List<string>();
        // Инициализируем индекс текущего разрешения.
        int currentResolutionIndex = 0;
        // Проходим по всем доступным разрешениям.
        for (int i = 0; i < resolutions.Length; i++)
        {
            // Форматируем строку для каждой опции
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            // Является ли текущее разрешение экрана текущим разрешением в списке
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        // Добавление вариантов разрешений из списка "options" в выпадающее меню.
        resolutionDropdown.AddOptions(options);
        // Устанавление текущего выбранное разрешение в выпадающем меню.
        resolutionDropdown.value = currentResolutionIndex;
        // Обновление отображения выпадающего меню, чтобы показать новые изменения.
        resolutionDropdown.RefreshShownValue();

        // Подписыватеся на событие изменения значения Dropdown
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    public void SetResolution(int resolutionIndex)
    {
        // Устанавливаем выбранное разрешение экрана
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
