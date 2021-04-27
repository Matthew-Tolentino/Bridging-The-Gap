using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform target;

    [Range(0f, 1f)]
    [SerializeField] float smoothSpeed = 0.25f;
    [SerializeField] Vector3 offset;

    void FixedUpdate() {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosiiton = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosiiton;

        // transform.LookAt(target);
    }
}
