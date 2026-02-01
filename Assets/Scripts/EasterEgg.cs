using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public static EasterEgg easterEgg;

    [SerializeField] private GameObject dreamMask;

    private Vector3 origPos;
    private float time = 0f;
    private bool scaring = false;

    private AudioSource audioSource;
    [SerializeField] private AudioClip jumpScare;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        easterEgg = this;
        dreamMask = this.gameObject;
        origPos = this.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scaring)
        {
            time += Time.deltaTime;
            dreamMask.transform.Translate(-Vector3.forward * Time.deltaTime * 3);
            if (time > 4f)
            {
                scaring = false;
                dreamMask.GetComponent<SpriteRenderer>().enabled = false;
                //dreamMask.transform.position = origPos;
            }
        }
    }

    public void JumpScare()
    {
        int random = Random.Range(0, 99);

        if (random < 1)
        {
            dreamMask.GetComponent<SpriteRenderer>().enabled = true;
            audioSource.clip = jumpScare;
            audioSource.Play();
            scaring = true;
        }
    }
}
