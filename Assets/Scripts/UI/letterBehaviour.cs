using UnityEngine;

public class letterBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

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
        CameraController.current.letter = this;
    }

    void onMouseExit()
    {
        CameraController.current.letter = this;
    }
}
