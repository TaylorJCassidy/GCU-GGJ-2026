using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TextSelect : MonoBehaviour, IPointerClickHandler
{
    //[SerializeField] TextMeshProUGUI buttonText; for changing text on the button
    [SerializeField] PuzzleController puzzleController;

    private int counter = 0;
    private bool tape = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puzzleController = transform.parent.GetChild(0).GetComponent<PuzzleController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (puzzleController.puzzleSolved)
        //{
        //    gameObject.GetComponent<UnityEngine.UI.Button>().enabled = false;
        //    gameObject.GetComponent<TextSelect>().enabled = false;
        //}
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ChangeColour();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Tape();
        }

    }

    public void ChangeColour()
    {
        if (!tape) 
        {
            if (counter == 0)
            {
                if (!puzzleController.puzzleSolved)
                {
                    //transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.red; //tape sprite to red
                    transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.red; //text to red
                    //gameObject.GetComponent<Image>().color = Color.red; //button to red

                    GameObject redLetter = gameObject;
                    puzzleController.puzzleRedLetters.Add(redLetter);

                    counter++;
                }
                else
                {
                    transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.yellow;
                    counter = 2;
                }
            }
            else if (counter == 1)
            {
                //transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.yellow; //tape sprite to yellow
                transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.yellow; //text to yellow
                //gameObject.GetComponent<Image>().color = Color.yellow; //button to yellow

                GameObject yellowLetter = gameObject;
                puzzleController.puzzleRedLetters.Remove(yellowLetter);

                counter++;
            }
            else
            {
                //transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.white; //back to default sprite
                transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.black; //text to black
                //gameObject.GetComponent<Image>().color = Color.white; //button to white

                GameObject blankLetter = gameObject;
                puzzleController.puzzleRedLetters.Remove(blankLetter);

                counter = 0;
            }
        }
    }

    public void Tape()
    {
        //right click adds/removes tape
        transform.GetChild(1).gameObject.SetActive(!tape);
        tape = !tape;
    }

    //for changing text on the button
    //public void NewText()
    //{
    //    buttonText.text = "H";
    //}
}
