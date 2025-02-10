using UnityEngine;
using UnityEngine.SceneManagement; // Dùng để chuyển Scene

public class MenuManager : MonoBehaviour
{
    // Hàm để bắt đầu game
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Chuyển sang Scene có tên "GameScene"
    }

    // Hàm thoát game
    public void QuitGame()
    {
        Application.Quit(); // Thoát ứng dụng
    }
}
