using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PuzzleController : MonoBehaviour
{
    public List<GameObject> puzzleRedLetters = new List<GameObject>();
    private string puzzleAttempt = "";
    public string puzzleAnswer = "";
    public bool puzzleSolved = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puzzleRedLetters = puzzleRedLetters.OrderBy(x => x.transform.position.x).ToList();
        puzzleRedLetters = puzzleRedLetters.OrderByDescending(y => y.transform.position.y).ToList();
        if (puzzleRedLetters.Count > 5)
        {
            CheckAnswer();
        }
    }

    public void CheckAnswer()
    {
        foreach (var x in puzzleRedLetters)
        {
            puzzleAttempt = puzzleAttempt + x.gameObject.name;
        }

        if (puzzleAttempt == puzzleAnswer)
        {
            puzzleSolved = true;
            Debug.Log("Puzzle is solved");
            puzzleRedLetters.Clear();
            puzzleAttempt = "";
        }
        else
        {
            puzzleAttempt = "";
        }
    }
}
