using Unity.VisualScripting;
using UnityEngine;

public class WordleModel : MonoBehaviour
{
    private int currentAttempt = 0;

    const int rowsOfCells = 6;
    const int columnsOfCells = 5;

    
    public Cell[,] cells = new Cell[rowsOfCells, columnsOfCells];

    [SerializeField]
    private TextAsset possibleAnswersAsset,
                      allowedWordsAsset;

    private string[] possibleAnswers;
    private string[] allowedAnswers;

    private string correctAnswer;


    // Start is called before the first frame update
    void Start()
    {

        correctAnswer = "asdfg";
        allowedAnswers = allowedWordsAsset.ToString().Split('\n');
        Debug.Log(allowedAnswers[Random.Range(0, allowedAnswers.Length)]);

        for(int r = 0; r < rowsOfCells ; r++)
        {
            for(int c = 0; c < columnsOfCells ; c++)
            {
                cells[r, c] = new Cell();
            }
        }

    }


    public void Setup()
    {
        #region Reset Cells Letters
        for (int r = 0; r < rowsOfCells; r++)
        {
            for (int c = 0; c < columnsOfCells; c++)
            {
                cells[r, c].Letter = '\0';
                cells[r,c].Color = Color.white;
            }
        }
        #endregion

        currentAttempt = 0;

    }

    public bool IsValidGuess(string s)
    {
        for(int i = 0; i < s.Length; i++)
        {
            if ( s[i] != correctAnswer[i] )
            {
                return false;
            }

        }

        return true;
    }

    public void UpdateCells(string userinputstring)
    {
        for(int i = 0; i < columnsOfCells; i++)
        {
            cells[currentAttempt, i].Letter = userinputstring[i];
            //Debug.Log(userinputstring[i]);
        }

        currentAttempt++;

    }


}
