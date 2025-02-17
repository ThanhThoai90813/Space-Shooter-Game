using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointBar : MonoBehaviour
{
    public TMP_Text pointText;
    public int point = 0;
    private int highScore;
    private TMP_Text highScoreText;
    private void Start()
    {
        GameObject highScoreObj = GameObject.FindGameObjectWithTag("HighScoreText");
        if (highScoreObj != null)
        {
            highScoreText = highScoreObj.GetComponent<TMP_Text>();
        }
        else
        {
            Debug.LogError("Không tìm thấy HighScoreText! Kiểm tra tag trong Unity.");
        }

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }

    public void IncreasePoint(int amount)
    {
        point += amount;
        UpdatePointText();

        GameManager.instance.IncreaseScore(amount);
        GameManager.instance.IncreaseSpeed();
    }

    void UpdatePointText()
    {
        if (pointText != null)
        {
            pointText.text = $"Point : {point}";
        }
    }

    public void UpdateHighScoreText()
    {
        if (point > highScore)
        {
            highScore = point;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); 
        }

        if (highScoreText != null)
        {
            highScoreText.text = $"High Point : {highScore}";
        }
    }
}
