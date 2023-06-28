using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
using TMPro;
public class CinemaCam : MonoBehaviour
{

    private CinemachineVirtualCamera vm;
    [SerializeField] private Transform target;
    public float maxDistance;
    public float minDistance;
    public float distance;
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;
    private float x = 0.0f;
    private float y = 0.0f;
    private void Start()
    {
        // Получаем компонент CinemachineFreeLook
        vm = GetComponent<CinemachineVirtualCamera>();
    }

    private void LateUpdate()
    {
        CameraMove();

    }
    private void CameraMove()
    {

        x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
        y = Mathf.Clamp(y, -45f, 20f);
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        Quaternion rotation = Quaternion.Euler(y, x, 0);

        target.rotation = rotation;
        vm.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = distance;
        distance -= Input.GetAxis("Mouse ScrollWheel") * 5.0f;
    }
}
