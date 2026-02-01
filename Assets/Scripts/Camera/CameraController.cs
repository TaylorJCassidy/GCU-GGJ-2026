using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController current;

    public float speed = 100f;
    public float rotationSpeed = 100f;
    float currentPitch = 0f;
    
    public bool cameraLocked;

    private Camera camera;

    void Start() {
        current = this;
        Cursor.lockState = CursorLockMode.Locked;
        camera = Camera.main;
    }

    void Update() 
    { 
        if (!cameraLocked) {
            float pitch = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            float yaw = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            currentPitch -= pitch;
            currentPitch = Mathf.Clamp(currentPitch, -85, 85);

            camera.transform.localRotation = Quaternion.Euler(currentPitch, 0f, 0f);
            transform.Rotate(new Vector3(0, yaw, 0));

            if (Input.GetKey(KeyCode.W)) 
            { 
                transform.localPosition += speed * Time.deltaTime * transform.forward;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.localPosition -=  speed * Time.deltaTime * transform.forward;
            }

            if (Input.GetKey(KeyCode.A)) 
            { 
                transform.localPosition -= speed * Time.deltaTime * transform.right;
            } 
            else if (Input.GetKey(KeyCode.D)) 
            { 
                transform.localPosition += speed * Time.deltaTime * transform.right;
            }
        }
    }
}
