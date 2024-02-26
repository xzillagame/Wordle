using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordleModel : MonoBehaviour
{
    private int currentAttempt;

    private Cell[,] cells = new Cell[6, 5];

    [SerializeField]
    private TextAsset possibleAnswersAsset,
                      allowedWordsAsset;

    private string[] possibleAnswers;
    private string[] allowedAnswers;

    private string correctAnswer;


    // Start is called before the first frame update
    void Start()
    {

        allowedAnswers = allowedWordsAsset.ToString().Split('\n');


        Debug.Log(allowedAnswers[Random.Range(0, allowedAnswers.Length)]);


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Setup()
    {

    }

    private bool isValidGuess(string s)
    {
        return false;
    }

    private void UpdateCells()
    {

    }


}
