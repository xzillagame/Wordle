using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordleController : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField input;

    [SerializeField]
    private WordleModel model;

    [SerializeField]
    private WordleView view;

    [SerializeField]
    private Button submissionButton;

    private List<string> previousSubmission = new List<string>(0);



    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    public void GameSetup()
    {
        model.Setup();
        view.Setup();
        submissionButton.interactable = true;
        input.text = string.Empty;
    }

    public void SubmitGuess()
    {
        string s = input.text.Trim();

        #region Verify if Input is of length 5 and is only characters

        if (s.Length != 5)
        {
            view.UserDisplayText = "Answer needs to be 5 characters";
            return;
        }

        #endregion

        # region Checks if input consits of only letters
        for (int i = 0; i < s.Length; i++)
        {
            if( char.IsLetter(s[i]) != true )
            {
                view.UserDisplayText = "Answer contains non-characters";
                return;
            }
        }
        #endregion

        #region Check if Answer was not in Previous Submission
        for (int i = 0; i < model.SubmittedAnswers.Count; i++)
        {
            if(s == model.SubmittedAnswers[i])
            {
                view.UserDisplayText = "Please Try New Answer!";
                return;
            }
        }
        #endregion

        #region Check if Answer is an Allowable Answer

        bool wordIsAllowableSubmission = false;

        for(int i = 0; i < model.AllowedWord.Length; i++)
        {
            if(s == model.AllowedWord[i].Trim())
            {
                //Is possible answer
                wordIsAllowableSubmission = true;

            }
        }

        for(int i = 0; i < model.PossibleAnswers.Length; i++)
        {

            if(s == model.PossibleAnswers[i].Trim())
            {
                wordIsAllowableSubmission = true;
            }

        }

        if(wordIsAllowableSubmission == false)
        {
            view.UserDisplayText = "Submission is not an allowable answer";
            return;
        }

        #endregion


        //Add word to list of submission
        model.SubmittedAnswers.Add(s);
        //Clear Display Text
        view.UserDisplayText = "";

        if (model.IsValidGuess(s.ToLower()))
        {
            WinGame();
        }
        if (model.CurrentAttempt == model.MaxAttempts - 1)
        {
            LoseGame();
        }

        model.UpdateCells(s);
        view.UpdateView(model.Cells);


    }

    private void WinGame()
    {
        view.UserDisplayText = "You Win!";
        submissionButton.interactable = false;
    }

    private void LoseGame()
    {
        view.UserDisplayText = "You Lose. Please Press Reset To Try Again.";
        submissionButton.interactable = false;
    }




}
