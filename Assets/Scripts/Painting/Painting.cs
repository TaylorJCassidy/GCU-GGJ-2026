using UnityEngine;

public class Painting : MonoBehaviour
{
    public int currentPosition;
    public int correctPosition;
    public bool locked;

    private void Awake()
    {
        locked = true;
    }

}
