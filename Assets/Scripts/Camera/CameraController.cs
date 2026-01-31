using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 100f;
    public float rotationSpeed = 100f;
    float currentPitch = 0f;

    bool onPlayer = true;

    public GameObject currentPlaque;
    private Camera camera;

    public static CameraController current;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        camera = Camera.main;
    }

    void Update() 
    { 
        float pitch = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        float yaw = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        currentPitch -= pitch;
        currentPitch = Mathf.Clamp(currentPitch, -85, 85);

        camera.transform.localRotation = Quaternion.Euler(currentPitch, 0f, 0f);
        transform.Rotate(new Vector3(0, yaw, 0));

        if (onPlayer == true)
        {
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
        else if (onPlayer == false)
        {
           if (Input.GetKey(KeyCode.E))
           {
                onPlayer = true;
            }

        }
    }
    }
    public void MoveToPlaque(GameObject plaque) {
        currentPlaque = plaque;
        if (currentPlaque != null)
        {
            //pan to object here//
        }
        else if (currentPlaque == null)
        {
            //pan back to player
        }
    }
}

