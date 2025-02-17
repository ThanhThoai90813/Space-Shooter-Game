using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // Dùng để chuyển Scene

public class MenuManager : MonoBehaviour
{
    public GameObject InstructionPanel;
    public TMP_Text[] scoreTexts;
    public GameObject HighScorePanel;
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Chuyển sang Scene có tên "GameScene"
    }

    public void ShowInstructions()
    {
        InstructionPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        InstructionPanel?.SetActive(false);
    }

    public void ShowHighScores()
    {
        HighScorePanel.SetActive(true);

        for (int i = 0; i < scoreTexts.Length; i++)
        {
            int score = PlayerPrefs.GetInt("HighScore" + i, 0);
            scoreTexts[i].text = (i + 1) + ". " + score;
        }
    }

    public void HideHighScores()
    {
        HighScorePanel.SetActive(false);
    }

    // Hàm thoát game
    public void QuitGame()
    {
        Application.Quit(); // Thoát ứng dụng
    }
}
