using TMPro;
using UnityEngine;

public class WordleController : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField input;

    [SerializeField]
    private WordleModel model;

    [SerializeField]
    private WordleView view;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void GameSetup()
    {

    }



    public void SubmitGuess()
    {
        string s = input.text.Trim();

        #region Verify if Input is of length 5 and is only characters
        if (s.Length != 5)
        {
            Debug.Log("Input is not valid");
            return;
        }

        for(int i = 0; i < s.Length; i++)
        {
            if( char.IsLetter(s[i]) != true )
            {
                Debug.Log("Input is not valid");
                return;
            }
        }
        #endregion


        Debug.Log(s + " is valid");

        model.IsValidGuess(s);

        model.UpdateCells(s);
        view.UpdateView(model.cells);

        


    }

    private void WinGame()
    {

    }

    private void LoseGame()
    {

    }




}
