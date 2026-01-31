using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PuzzleController : MonoBehaviour
{
    public List<GameObject> puzzleRedLetters = new List<GameObject>();
    private string puzzleAttempt = "";
    public string puzzleAnswer = "";
    private bool duplicateFound = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puzzleRedLetters = puzzleRedLetters.OrderBy(x => x.transform.position.x).ToList();
        puzzleRedLetters = puzzleRedLetters.OrderByDescending(y => y.transform.position.y).ToList();
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            CheckAnswer();
        }
    }

    public void CheckAnswer()
    {
        foreach (var x in puzzleRedLetters)
        {
            if (puzzleAttempt.Contains(x.name))
            {
                duplicateFound = true;
            }

            

            puzzleAttempt = puzzleAttempt + x.gameObject.name;
        }

        if (duplicateFound == false && puzzleAttempt == puzzleAnswer)
        {
            Debug.Log("Puzzle Solved");
            puzzleAttempt = "";
            duplicateFound = false;
        }
        else
        {
            puzzleAttempt = "";
            duplicateFound = false; 
        }
    }
}
