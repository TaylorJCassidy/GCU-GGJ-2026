using UnityEngine;

public class Painting : MonoBehaviour
{
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        { 
            PlayerController.current.SetCurrentPainting(this);
        }
    }
}
