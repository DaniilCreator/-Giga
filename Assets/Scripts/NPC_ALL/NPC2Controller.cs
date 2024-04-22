using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2Controller : MonoBehaviour
{
    public float moveSpeed = 2f; // Скорость движения НПС
    public float detectionRadius = 5f; // Радиус обнаружения игрока
    public LayerMask playerLayer; // Слой, на котором находится игрок

    public Vector2 topLeftBounds = new Vector2(-8f, 4.5f); // Верхняя левая граница экрана
    public Vector2 bottomRightBounds = new Vector2(8f, -4.5f); // Нижняя правая граница экрана

    private Transform player; // Ссылка на трансформ игрока
    private Vector3 randomDestination; // Случайная точка назначения для случайного движения

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Найти игрока по тегу "Player"
        UpdateRandomDestination(); // Обновить случайную точку назначения
    }

    void Update()
    {
        // Если игрок находится в радиусе обнаружения
        if (Vector3.Distance(transform.position, player.position) < detectionRadius)
        {
            // Отходим от игрока
            Vector3 directionFromPlayer = (transform.position - player.position).normalized;
            transform.position += directionFromPlayer * moveSpeed * Time.deltaTime;
        }
        else
        {
            // Если игрок вне радиуса обнаружения, двигаемся к случайной точке
            if (Vector3.Distance(transform.position, randomDestination) < 0.1f)
            {
                UpdateRandomDestination(); // Обновляем случайную точку назначения
            }
            else
            {
                // Двигаемся к случайной точке
                Vector3 directionToDestination = (randomDestination - transform.position).normalized;
                transform.position += directionToDestination * moveSpeed * Time.deltaTime;
            }
        }
    }

    // Генерация случайной точки назначения в пределах ограничений экрана
    void UpdateRandomDestination()
    {
        randomDestination = new Vector3(Random.Range(topLeftBounds.x, bottomRightBounds.x), Random.Range(bottomRightBounds.y, topLeftBounds.y), 0f); // Использование границ экрана
    }

    // Отображение границ экрана в редакторе
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(topLeftBounds.x, topLeftBounds.y, 0f), new Vector3(bottomRightBounds.x, topLeftBounds.y, 0f));
        Gizmos.DrawLine(new Vector3(bottomRightBounds.x, topLeftBounds.y, 0f), new Vector3(bottomRightBounds.x, bottomRightBounds.y, 0f));
        Gizmos.DrawLine(new Vector3(bottomRightBounds.x, bottomRightBounds.y, 0f), new Vector3(topLeftBounds.x, bottomRightBounds.y, 0f));
        Gizmos.DrawLine(new Vector3(topLeftBounds.x, bottomRightBounds.y, 0f), new Vector3(topLeftBounds.x, topLeftBounds.y, 0f));
    }
}
