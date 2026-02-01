using UnityEngine;

public class Plaque : MonoBehaviour
{
    bool focussed = false;

    Vector3 oldCameraPosition;
    Quaternion oldCameraRotation;

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            focussed = !focussed;
            CameraController.current.cameraLocked = focussed;
            if (focussed) {
                oldCameraPosition = Camera.main.gameObject.transform.position;
                oldCameraRotation = Camera.main.gameObject.transform.rotation;
                Camera.main.gameObject.transform.position = transform.position + new Vector3(-0.37f, 0f, -0.37f);
                Camera.main.gameObject.transform.LookAt(transform, Vector3.up);
                print("focussed");
            }
            else {
                Camera.main.gameObject.transform.position = oldCameraPosition;
                Camera.main.gameObject.transform.rotation = oldCameraRotation;
                print("not focussed");
            }
        }
    }
}