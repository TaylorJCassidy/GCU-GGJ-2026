using UnityEngine;

public class plaqueBehaviour : MonoBehaviour
{
    private GameObject currentPlaque;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPlaque = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onMouseOver()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (currentPlaque != null)
            {
                if (CameraController.current.currentPlaque == null)
                {
                    CameraController.current.MoveToPlaque(currentPlaque);
                }
            else
                {
                    CameraController.current.MoveToPlaque(currentPlaque);
                }
            }
        else
                {
                    if (CameraController.current.currentPlaque != null)
                    {
                        //MoveToPlaque(CameraController.current.currentPlaque);;
                    }
                }
            }
        }

    }


