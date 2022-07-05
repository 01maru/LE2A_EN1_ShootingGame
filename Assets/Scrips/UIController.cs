using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static int score = 0;
    public static int playerHP = 1;
    GameObject scoreText;

    public static void ResetHP()
    {
        playerHP = 1;
    }

    public static void SubPlayerHP()
    {
        playerHP -= 1;
    }

    public void AddScore()
    {
        if (UIController.playerHP != 0)
        {
            score += 100;
        }
    }

    public void ScoreReset()
    {
        score = 0;
    }

    public static int GetScore()
    {
        return score;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score:" + score.ToString("D4");
    }
}
