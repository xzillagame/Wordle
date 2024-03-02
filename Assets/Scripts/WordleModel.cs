using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class WordleModel : MonoBehaviour
{
    private int currentAttempt = 0;
    public int CurrentAttempt { get { return currentAttempt; } }
    private const int MAXATTEMPT = 6;
    public int MaxAttempts { get { return MAXATTEMPT; } }

    const int ROWSOFCELLS = 6;
    const int COLUMNSOFCELLS = 5;


    #region 2D Array of Cells
    [SerializeField]
    private Cell[,] cells = new Cell[ROWSOFCELLS, COLUMNSOFCELLS];
    public Cell[,] Cells { get { return cells; } }
    #endregion


    [SerializeField]
    private TextAsset possibleAnswersAsset,
                      allowedWordsAsset;


    #region PossibleAnswers
    private string[] possibleAnswers;
    public string[] PossibleAnswers { get { return possibleAnswers; } }
    #endregion

    #region AllowedWord
    private string[] allowedWord;
    public string[] AllowedWord { get { return allowedWord; } }
    #endregion

    #region SubmittedAnswers
    private List<string> submittedAnswers = new List<string>();
    public List<string> SubmittedAnswers { get { return submittedAnswers; } }

    #endregion

    private string correctAnswer;


    // Start is called before the first frame update
    void Start()
    {
        allowedWord = allowedWordsAsset.ToString().Split('\n');
        possibleAnswers= possibleAnswersAsset.ToString().Split("\n");

        for(int r = 0; r < ROWSOFCELLS ; r++)
        {
            for(int c = 0; c < COLUMNSOFCELLS ; c++)
            {
                cells[r, c] = new Cell();
            }
        }

    }


    public void Setup()
    {
        #region Reset Cells Letters
        for (int r = 0; r < ROWSOFCELLS; r++)
        {
            for (int c = 0; c < COLUMNSOFCELLS; c++)
            {
                cells[r, c].Letter = '\0';
                cells[r,c].Color = Color.white;
            }
        }
        #endregion


        correctAnswer = possibleAnswers[Random.Range(0, possibleAnswers.Length)].Trim();
        Debug.Log(correctAnswer);

        currentAttempt = 0;
        submittedAnswers.Clear();

    }

    public bool IsValidGuess(string s)
    {
        bool answerMatches = false;

        if (s == correctAnswer)
        {
            answerMatches = true;

            for (int c = 0; c < COLUMNSOFCELLS; c++)
            {
                cells[currentAttempt, c].Color = Color.green;
            }

        }
        else
        {

            for (int i = 0; i < s.Length; i++)
            {

                cells[currentAttempt, i].Letter = s[i];

                if (correctAnswer[i] == s[i])
                {
                    cells[currentAttempt, i].Color = Color.green;
                }
                else
                {
                    cells[currentAttempt, i].Color = Color.red;
                }
            }


            for (int currentCell = 0; currentCell < COLUMNSOFCELLS; currentCell++)
            {
                int totalLetterCounterAnswer = 0;
                int totalLetterCounterInput = 0;

                for (int i = 0; i < COLUMNSOFCELLS; i++)
                {
                    if (correctAnswer[currentCell] == correctAnswer[i])
                    {
                        totalLetterCounterAnswer++;
                    }

                    if (correctAnswer[currentCell] == s[i])
                    {
                        totalLetterCounterInput++;
                    }

                }


                if (totalLetterCounterInput == totalLetterCounterAnswer)
                {
                    //At miniumum yellow or green

                    for (int cellCounter = 0; cellCounter < COLUMNSOFCELLS; cellCounter++)
                    {
                        if (cells[currentAttempt, cellCounter].Letter == correctAnswer[currentCell] &&
                            cells[currentAttempt, cellCounter].Color == Color.red)
                        {
                            cells[currentAttempt, cellCounter].Color = Color.yellow;
                        }
                    }

                }
                else if (totalLetterCounterInput < totalLetterCounterAnswer)
                {
                    for (int i = 0; i < COLUMNSOFCELLS && totalLetterCounterInput < totalLetterCounterAnswer; i++)
                    {
                        if (cells[currentAttempt, i].Letter == correctAnswer[currentCell] &&
                            cells[currentAttempt, i].Color == Color.red)
                        {
                            cells[currentAttempt, i].Color = Color.yellow;
                            totalLetterCounterInput++;
                        }
                    }
                }

            }

        }


        return answerMatches;

    }
    public void UpdateCells(string userinputstring)
    {
        for(int i = 0; i < COLUMNSOFCELLS; i++)
        {
            cells[currentAttempt, i].Letter = userinputstring[i];
        }

        currentAttempt++;

    }


}
