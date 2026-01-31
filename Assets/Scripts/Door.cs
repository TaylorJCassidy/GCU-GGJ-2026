using UnityEngine;

public class Door : MonoBehaviour
{
    bool opening = false;
    float time = 0f;

    public AnimationCurve animationCurve;

    // Update is called once per frame
    void Update()
    {
        if (opening == true) {
            time += Time.deltaTime;
            float rotationSpeed = animationCurve.Evaluate(time);
            transform.Rotate(new Vector3(0f, -rotationSpeed, 0f));
            if (time > 2.1f) opening = false;
        }
    }

    public void OpenDoor() {
        opening = true;
    }
}
