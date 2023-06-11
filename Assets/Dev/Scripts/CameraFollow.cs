using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target; // Takip edilecek hedefin referansı
    public float smoothSpeed = 0.125f; // Takip etme hızı

    private Vector3 offset;

    private void Start() {
        offset = transform.position - target.position;
    }

    private void LateUpdate() {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}