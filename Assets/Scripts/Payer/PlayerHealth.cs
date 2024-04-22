using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное количество здоровья игрока
    public int currentHealth; // Текущее количество здоровья игрока

    public Slider healthSlider; // Ссылка на слайдер здоровья в UI

    private bool isInvulnerable = false; // Флаг, указывающий на то, что игрок находится в состоянии невосприимчивости

    void Start()
    {
        currentHealth = maxHealth; // Устанавливаем начальное здоровье игрока
        UpdateHealthUI(); // Обновляем UI здоровья
    }

    public void TakeDamage(int damageAmount)
    {
        if (!isInvulnerable)
        {
            currentHealth -= damageAmount; // Вычитаем урон из текущего здоровья игрока

            // Проверяем, не упало ли здоровье игрока ниже нуля
            if (currentHealth <= 0)
            {
                Die(); // Если да, вызываем метод смерти
            }
            else
            {
                StartCoroutine(InvulnerabilityCooldown()); // Запускаем корутину для установки времени невосприимчивости
            }

            UpdateHealthUI(); // Обновляем UI здоровья
        }
    }

    void Die()
    {
        // Метод вызывается, когда здоровье игрока достигает нуля или менее
        // Здесь можно добавить дополнительные действия, например, анимацию смерти или перезагрузку уровня
        Debug.Log("Player has died!");
    }

    void UpdateHealthUI()
    {
        // Обновляем значение слайдера здоровья в соответствии с текущим здоровьем игрока
        healthSlider.value = currentHealth;
    }

    IEnumerator InvulnerabilityCooldown()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(3f); // Устанавливаем время невосприимчивости на 3 секунды
        isInvulnerable = false;
    }
}
