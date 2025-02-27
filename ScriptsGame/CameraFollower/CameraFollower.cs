// Gorney-Alex script

using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 10, -10);
    [SerializeField] private float smoothSpeed = 1f;
    [SerializeField] private float fixedHeight = 1f;

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + target.rotation * offset;
        desiredPosition.y = target.position.y + fixedHeight;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);

        Quaternion targetRotation = Quaternion.Euler(10f, target.eulerAngles.y, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothSpeed * Time.fixedDeltaTime);
    }
}
