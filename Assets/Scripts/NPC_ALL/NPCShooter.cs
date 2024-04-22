using UnityEngine;

public class NPCShooter : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public Transform firePoint; // Точка, откуда будут вылетать пули
    public float fireRate = 1f; // Частота выстрелов
    public float bulletSpeed = 5f; // Скорость пули

    private Transform player; // Ссылка на трансформ игрока
    private NPC2Controller npcController; // Ссылка на компонент управления NPC
    private float nextFireTime = 0f; // Время до следующего выстрела

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Найти игрока по тегу "Player"
        npcController = GetComponent<NPC2Controller>(); // Получить компонент NPC2Controller
    }

    void Update()
    {
        // Если игрок находится в радиусе обнаружения и время выстрела пришло
        if (npcController != null && Vector3.Distance(transform.position, player.position) < npcController.detectionRadius && Time.time >= nextFireTime)
        {
            // Направляем префаб пули на игрока
            Vector3 direction = (player.position - firePoint.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

            // Стреляем
            Shoot(rotation);

            nextFireTime = Time.time + 1f / fireRate; // Обновляем время следующего выстрела
        }
    }

    // Функция для стрельбы
    void Shoot(Quaternion rotation)
    {
        // Создаем экземпляр пули в позиции firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);

        // Выравниваем пулю так, чтобы ее направление совпадало с направлением firePoint
        bullet.transform.right = firePoint.right;

        // Наносим скорость пуле в направлении, определенном firePoint
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed;
    }
}
