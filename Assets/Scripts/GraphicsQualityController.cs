using UnityEngine;
using UnityEngine.UI;

public class GraphicsQualityController : MonoBehaviour
{
    public Dropdown qualityDropdown;

    private void Start()
    {
        // Инициализируем выпадающий список с имеющимися уровнями качества
        qualityDropdown.ClearOptions();
        qualityDropdown.AddOptions(new System.Collections.Generic.List<string>(QualitySettings.names));

        // Устанавливаем текущий уровень качества в качестве выбранного в списке
        qualityDropdown.value = QualitySettings.GetQualityLevel();
    }

    public void SetQualityLevel(int qualityIndex)
    {
        // Устанавливаем выбранный уровень качества
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
