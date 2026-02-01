using UnityEngine;

public class Door : MonoBehaviour
{
    bool opening = false;
    float time = 0f;
    public float curveMultiplier = 1f;

    public AnimationCurve animationCurve;

    private AudioSource audioSource;
    [SerializeField] private AudioClip doorOpen;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (opening) {
            time += Time.deltaTime;
            float rotationSpeed = animationCurve.Evaluate(time) * curveMultiplier * Time.deltaTime;
            transform.Rotate(new Vector3(0f, -rotationSpeed, 0f));
            if (time > 4f) opening = false;
        }
    }

    public void OpenDoor() {
        audioSource.clip = doorOpen;
        audioSource.Play();
        opening = true;
    }
}
