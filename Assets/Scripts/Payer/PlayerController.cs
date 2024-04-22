using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Скорость перемещения персонажа

    void Update()
    {
        // Получаем ввод с клавиатуры по осям WASD
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVertical = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1f;
        }

        // Создаем вектор направления движения на основе ввода
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);

        // Нормализуем вектор направления движения, чтобы скорость перемещения была одинаковой по диагонали
        movement.Normalize();

        // Применяем перемещение к позиции персонажа
        transform.position += movement * speed * Time.deltaTime;
    }
}
