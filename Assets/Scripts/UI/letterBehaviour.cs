using UnityEngine;

public class letterBehaviour : MonoBehaviour
{

    bool focussed = false;

    public GameObject letter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E) && !focussed)
        {
            focussed = true;
            CameraController.current.cameraLocked = true;
            letter.SetActive(true);
        }
    }

    public void Unfocus() {
        focussed = false;
        CameraController.current.cameraLocked = false;
        letter.SetActive(false);
    }
}
