using NUnit.Framework;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] PuzzleController puzzle1Controller;
    [SerializeField] PuzzleController puzzle2Controller;
    [SerializeField] PuzzleController puzzle3Controller;
    [SerializeField] PuzzleController puzzle4Controller;

    private bool puzzle1Solved, puzzle2Solved, puzzle3Solved, puzzle4Solved;

    private AudioSource audioSource;
    [SerializeField] private AudioClip paintingUnlock;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puzzle1Controller = GameObject.Find("Puzzle1Controller").GetComponent<PuzzleController>();
        puzzle2Controller = GameObject.Find("Puzzle2Controller").GetComponent<PuzzleController>();
        puzzle3Controller = GameObject.Find("Puzzle3Controller").GetComponent<PuzzleController>();
        puzzle4Controller = GameObject.Find("Puzzle4Controller").GetComponent<PuzzleController>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzle1Controller.puzzleSolved && !puzzle1Solved)
        {
            //unlock painting one
            Debug.Log("Puzzle 1 is solved");
            PuzzleSolved();
            puzzle1Solved = true; //prevents this if constantly firing
        }

        if (puzzle2Controller.puzzleSolved && !puzzle2Solved)
        {
            //unlock painting two
            Debug.Log("Puzzle 2 is solved");
            PuzzleSolved();
            puzzle2Solved = true; //prevents this if constantly firing
        }

        if (puzzle3Controller.puzzleSolved && !puzzle3Solved)
        {
            //unlock painting three
            Debug.Log("Puzzle 3 is solved");
            PuzzleSolved();
            puzzle3Solved = true; //prevents this if constantly firing
        }

        if (puzzle4Controller.puzzleSolved && !puzzle4Solved)
        {
            //unlock painting four
            Debug.Log("Puzzle 4 is solved");
            PuzzleSolved();
            puzzle4Solved = true; //prevents this if constantly firing
        }
    }

    private void PuzzleSolved()
    {
        audioSource.clip = paintingUnlock;
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play();
    }
}
