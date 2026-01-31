using System.Collections.Generic;
using UnityEngine;

public class PaintingController : MonoBehaviour
{
    public static PaintingController current;

    public List<Painting> paintings;

    public Door door;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current = this;
    }

    public void UnlockPaintings() {
       foreach(Painting painting in paintings) {
            painting.locked = false;
        } 
    }

    public void CheckPaintingOrder() {
        bool allCorrect = true;
        foreach(Painting painting in paintings) {
            allCorrect &= painting.correctPosition == painting.currentPosition;
        }
        if (allCorrect) {
            door.OpenDoor();
        }
    }
}
