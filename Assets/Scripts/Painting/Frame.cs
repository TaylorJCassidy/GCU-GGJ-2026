using UnityEngine;

public class Frame : MonoBehaviour
{
    private GameObject currentPainting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPainting = transform.GetChild(0).gameObject;
    }

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        { 
            if (currentPainting != null) {
                if (PlayerController.current.currentPainting == null) {
                    PlayerController.current.SetCurrentPainting(currentPainting);
                    SetCurrentPainting(null);
                }
                else {
                    GameObject playerPainting = PlayerController.current.currentPainting;
                    PlayerController.current.SetCurrentPainting(currentPainting);
                    SetCurrentPainting(playerPainting);
                }
            }
            else {
                if (PlayerController.current.currentPainting != null) {
                    SetCurrentPainting(PlayerController.current.currentPainting);
                    PlayerController.current.SetCurrentPainting(null);
                }
            }
            
        }
    }

    public void SetCurrentPainting(GameObject painting) {
        currentPainting = painting;
        if (currentPainting != null) {
            currentPainting.transform.parent = transform;
            currentPainting.transform.localPosition = new Vector3(0f, 0.1f, 0f);
            currentPainting.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
