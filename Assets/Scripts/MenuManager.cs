using UnityEngine;
using UnityEngine.SceneManagement; // Dùng để chuyển Scene

public class MenuManager : MonoBehaviour
{
    public GameObject InstructionPanel;
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

    // Hàm thoát game
    public void QuitGame()
    {
        Application.Quit(); // Thoát ứng dụng
    }
}
