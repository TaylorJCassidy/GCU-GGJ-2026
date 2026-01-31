using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController current;

    private Painting currentPainting = null;

    public GameObject wall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentPainting(Painting painting)
    {
        if (painting != null) {
            currentPainting.transform.position = painting.transform.position;
            currentPainting.transform.SetParent(painting.transform);
        }
        currentPainting = painting;
        currentPainting.transform.SetParent(transform);
        
    }
}
