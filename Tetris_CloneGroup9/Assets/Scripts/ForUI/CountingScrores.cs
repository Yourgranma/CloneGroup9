using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountingScrores : MonoBehaviour
{
    public int score = 0;
    public int _numberOfLines;
    public int level = 0;
    private int nextlevel = 10;
    int currentScore;
    int previousScore;
    int[] tetroCount = new int[7];
    public TextMeshProUGUI _score;
    public TextMeshProUGUI _lines;
    public TextMeshProUGUI _level;
    public TextMeshProUGUI[] _numberOfTretominos= new TextMeshProUGUI[7];

    bool _scoreDelay;
    // Start is called before the first frame update
    void Start()
    {
        _level.text = level.ToString();
        _numberOfLines = 0;
        _scoreDelay = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _lines.text = "Lines-" + _numberOfLines.ToString();
        if (_score != null)
        {
            _score.text = score.ToString();
        }
        for(int i = 0; i < 7;  i++)
        {
            _numberOfTretominos[i].text = tetroCount[i].ToString();
        }
        currentScore = score;
    }

    public void CountingScore(int scoreToAdd)
    {
        StartCoroutine(ScoreDelay());
        score = score + scoreToAdd;
        if (currentScore - previousScore == 2)
        {
            score = score + 2;
        }
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

    public void Levels()
    {
        if (_numberOfLines == nextlevel)
        {
            ++level;
            nextlevel = nextlevel + 10;
        }
    }
    public void Bonuses()
    {
        if (_scoreDelay)
        {
            previousScore = currentScore;
            
            _scoreDelay = false;
        }
       
    }

    IEnumerator ScoreDelay()
    {
        _scoreDelay = false;
        yield return new WaitForSeconds(2);
        _scoreDelay = true;
    }
}
