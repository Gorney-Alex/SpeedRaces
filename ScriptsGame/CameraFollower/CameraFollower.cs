// Gorney-Alex script

using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target; // Игрок
    [SerializeField] private Vector3 offset = new Vector3(0, 10, -10); // Смещение камеры
    [SerializeField] private float smoothSpeed = 5f; // Скорость сглаживания

    private void LateUpdate()
    {
        if (target == null) return;

        // Определяем целевую позицию (НЕ зависящую от поворота)
        Vector3 desiredPosition = target.position + target.transform.forward * offset.z + Vector3.up * offset.y;

        // Отключаем движение по оси Y, используя текущую позицию камеры по Y
        desiredPosition.y = transform.position.y;

        // Плавно перемещаем камеру
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Камера всегда смотрит на игрока (фикс переворота)
        transform.LookAt(target.position + Vector3.up * 2f); // Можно подстроить значение 2f, если нужно
    }
}
