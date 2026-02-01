using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController current;

    public Painting currentPainting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current = this;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            UIController.current.ToggleMenu();
        }
    }

    public void SetCurrentPainting(Painting painting) {
        currentPainting = painting;
        if (currentPainting != null) {
            currentPainting.transform.parent = transform;
            currentPainting.transform.SetLocalPositionAndRotation(new Vector3(0.35f, -0.35f, 0.5f), Quaternion.Euler(90f, 210f, 15f));
        }
    }
}
