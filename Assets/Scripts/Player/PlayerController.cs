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

    public void SetCurrentPainting(Painting painting) {
        currentPainting = painting;
        if (currentPainting != null) {
            currentPainting.transform.parent = transform;
            currentPainting.transform.localPosition = new Vector3(0.5f, -0.35f, 1f);
            currentPainting.transform.localRotation = Quaternion.Euler(-90f, 15f, 15f);
        }
    }
}
