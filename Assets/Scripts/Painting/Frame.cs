using UnityEngine;

public class Frame : MonoBehaviour
{
    private Painting currentPainting;
    private int position;

    private AudioSource audioSource;
    [SerializeField] private AudioClip paintingPickup;
    [SerializeField] private AudioClip paintingPutdown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPainting = transform.GetComponentInChildren<Painting>();
        position = currentPainting.currentPosition;

        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (currentPainting != null) {
                if (currentPainting.locked) return;
                audioSource.clip = paintingPickup;
                audioSource.pitch = Random.Range(0.8f, 1.2f);
                audioSource.Play();
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
                    audioSource.clip = paintingPutdown;
                    audioSource.pitch = Random.Range(0.8f, 1.2f);
                    audioSource.Play();
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
            currentPainting.transform.SetLocalPositionAndRotation(new Vector3(0f, 0.1f, 0f), Quaternion.Euler(0f, 0f, 0f));
            currentPainting.currentPosition = position;
            PaintingController.current.CheckPaintingOrder();    
        }
    }
}
