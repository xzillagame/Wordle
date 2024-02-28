using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordleView : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rows;


    public void Setup()
    {

        for (int r = 0; r < rows.Length; r++)
        {
            Button[] myButtonArray = rows[r].GetComponentsInChildren<Button>();

            for (int c = 0; c < myButtonArray.Length; c++)
            {
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
                }

            }



        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
