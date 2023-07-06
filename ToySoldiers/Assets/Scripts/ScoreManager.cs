using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    private int score;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        updateScore();
    }

    public int getScore()
    {
        return score;
    }

    public void addScore(int scoreIn)
    {
        score += scoreIn;
        updateScore();
    }

    public void setScore(int scoreIn)
    {
        score = scoreIn;
        updateScore();
    }

    public void updateScore()
    {
        scoreText.text = "Box's Destoryed : " + score;
    }
}
