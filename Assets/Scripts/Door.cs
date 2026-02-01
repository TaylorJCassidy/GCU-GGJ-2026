using UnityEngine;

public class Door : MonoBehaviour
{
    bool opening = false;
    float time = 0f;
    public float curveMultiplier = 1f;

    public AnimationCurve animationCurve;

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
        opening = true;
    }
}
