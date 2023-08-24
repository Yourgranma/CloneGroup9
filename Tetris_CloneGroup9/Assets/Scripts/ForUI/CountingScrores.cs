using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountingScrores : MonoBehaviour
{
    public int score = 0;
    int[] tetroCount = new int[7];
    public TextMeshProUGUI _score;
    public TextMeshProUGUI[] _numberOfTretominos= new TextMeshProUGUI[7];
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_score != null)
        {
            _score.text = "Score: " + score.ToString();
        }
        for(int i = 0; i < 7;  i++)
        {
            _numberOfTretominos[i].text = tetroCount[i].ToString();
        }
        
    }

    public void CountingScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
    }

    public void TetrisNumber(int number)
    {
        if (number == 0)
        {
            ++tetroCount[0];
            Debug.Log("I");
        }
        else if (number == 1)
        {
            ++tetroCount[1];
            Debug.Log("O");
        }

        else if (number == 2)
        {
            ++tetroCount[2];
            Debug.Log("T");
        }

        else if (number == 3)
        {
            ++tetroCount[3];
            Debug.Log("J");
        }

        else if (number == 4)
        {
            ++tetroCount[4];
            Debug.Log("L");

        }

        else if (number == 5)
        {
            ++tetroCount[5];
            Debug.Log("S");
        }

        else if (number == 6)
        {
            ++tetroCount[6];
            Debug.Log("Z");
        }
    }
}
