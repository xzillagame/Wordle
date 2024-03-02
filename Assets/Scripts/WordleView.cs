using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordleView : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rows;

    [SerializeField]
    private TMP_Text gameStateDisplayToUser;

    public string UserDisplayText 
    {
        set { gameStateDisplayToUser.text = value; }
    }


    public void Setup()
    {
        gameStateDisplayToUser.text = "";

        for (int r = 0; r < rows.Length; r++)
        {
            Button[] myButtonArray = rows[r].GetComponentsInChildren<Button>();

            for (int c = 0; c < myButtonArray.Length; c++)
            {
                myButtonArray[c].image.color = Color.white;
                myButtonArray[c].GetComponentInChildren<TMP_Text>().text = "";
            }
        }

    }

    public void UpdateView(Cell[,] cells)
    {

        for (int r = 0; r < rows.Length; r++)
        {

            Button[] myButtonArray = rows[r].GetComponentsInChildren<Button>();

            for(int c = 0; c < myButtonArray.Length; c++)
            {

                if (cells[r, c].Letter != '\0')
                {
                    myButtonArray[c].GetComponentInChildren<TMP_Text>().text = cells[r, c].Letter.ToString();
                    myButtonArray[c].image.color = cells[r, c].Color;
                }

            }



        }
    }


}
