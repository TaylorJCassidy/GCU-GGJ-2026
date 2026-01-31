using UnityEngine;

public class Frame : MonoBehaviour
{
    private Painting currentPainting;
    private int position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPainting = transform.GetComponentInChildren<Painting>();
        position = currentPainting.currentPosition;
    }

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (currentPainting != null) {
                if (currentPainting.locked) return;
                if (PlayerController.current.currentPainting == null) {
                    PlayerController.current.SetCurrentPainting(currentPainting);
                    SetCurrentPainting(null);
                }
                else {
                    Painting playerPainting = PlayerController.current.currentPainting;
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

    public void SetCurrentPainting(Painting painting) {
        currentPainting = painting;
        if (currentPainting != null) {
            currentPainting.transform.parent = transform;
            currentPainting.transform.localPosition = new Vector3(0f, 0.1f, 0f);
            currentPainting.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            currentPainting.currentPosition = position;
            PaintingController.current.CheckPaintingOrder();    
        }
    }
}
