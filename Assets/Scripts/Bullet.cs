using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount = 30; // Количество урона, который наносит пуля игроку
    public float speed = 10f; // Скорость пули

    private Transform player; // Ссылка на трансформ игрока

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Найти игрока по тегу "Player"

        // Запускаем таймер для уничтожения пули через некоторое время,
        // чтобы избежать "зависания" пуль в сцене
        Destroy(gameObject, 3f);

        // Получаем Rigidbody2D пули
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Вычисляем направление к игроку, игнорируя разницу в Z координатах
        Vector2 directionToPlayer = (new Vector2(player.position.x, player.position.y) - new Vector2(transform.position.x, transform.position.y)).normalized;

        // Пуля будет двигаться по направлению к игроку
        rb.velocity = directionToPlayer * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, столкнулась ли пуля с игроком
        if (other.CompareTag("Player"))
        {
            // Получаем компонент здоровья игрока
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Проверяем, был ли найден компонент здоровья игрока
            if (playerHealth != null)
            {
                // Наносим урон игроку
                playerHealth.TakeDamage(damageAmount);
            }

            // Уничтожаем пулю после столкновения с игроком
            Destroy(gameObject);
        }
    }
}
