using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class WordleModel : MonoBehaviour
{
    private int currentAttempt = 0;

    const int ROWSOFCELLS = 6;
    const int COLUMNSOFCELLS = 5;

    
    public Cell[,] cells = new Cell[ROWSOFCELLS, COLUMNSOFCELLS];

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


        for(int r = 0; r < ROWSOFCELLS ; r++)
        {
            for(int c = 0; c < COLUMNSOFCELLS ; c++)
            {
                cells[r, c] = new Cell();
            }
        }

        Setup();

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


        correctAnswer = "gnoos";//allowedAnswers[Random.Range(0, allowedAnswers.Length)].Trim();
        Debug.Log(correctAnswer);


        currentAttempt = 0;

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
                    //At miniumum blue or green

                    for (int cellCounter = 0; cellCounter < COLUMNSOFCELLS; cellCounter++)
                    {
                        if (cells[currentAttempt, cellCounter].Letter == correctAnswer[currentCell] &&
                            cells[currentAttempt, cellCounter].Color == Color.red)
                        {
                            cells[currentAttempt, cellCounter].Color = Color.blue;
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
                            cells[currentAttempt, i].Color = Color.blue;
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
