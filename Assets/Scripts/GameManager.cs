using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject enemyPrefab;
    public GameObject starPrefab;
    public float minInstantiateValue;
    public float maxInstantiateValue;
    public float enemyDestroyTime = 10f;
    public float starDestroyTime = 10f;
	public AudioSource deathSound, starPickupSound, gameOverSound;

	[Header("Particle Effects")]
    public GameObject explosion;
    public GameObject muzzleFlash;

    [Header("Enemy Speed Settings")]
    public float enemyFallSpeed = 2f; // Tốc độ rơi ban đầu
    public float speedIncreasePerPoint = 0.2f; // Mỗi điểm tăng thêm tốc độ bao nhiêu

    public GameObject GameOverScreen;
    public TMP_Text gameOverPointText;
    public ScrollingRandomBackground scrollingBackground;
    private int playerScore = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        InvokeRepeating("InstantiateEnemy", 1f, 2f);
        InvokeRepeating("InstantiateStar", 1f, 3f);
    }

    void InstantiateEnemy()
    {
        Vector3 enemypos = new Vector3(Random.Range(minInstantiateValue, maxInstantiateValue), 10f);
        GameObject enemy = Instantiate(enemyPrefab, enemypos, Quaternion.Euler(0f,0f,180f));
       
        // Gán tốc độ mới cho enemy
        EnemyController enemyScript = enemy.GetComponent<EnemyController>();
        if (enemyScript != null)
        {
            enemyScript.fallSpeed = enemyFallSpeed;
        }
        Destroy(enemy, enemyDestroyTime);
    }

    public void IncreaseSpeed()
    {
        enemyFallSpeed += speedIncreasePerPoint;

         if (scrollingBackground != null)
        {
            scrollingBackground.IncreaseSpeed(playerScore);
        }
    }

    public void IncreaseScore(int amount)
    {
        playerScore += amount;
    }

    void InstantiateStar() 
    {
        Vector3 starPos = new Vector3(Random.Range(minInstantiateValue, maxInstantiateValue), 10f);
        GameObject star = Instantiate(starPrefab, starPos, Quaternion.identity);
        Destroy(star, starDestroyTime);
    }
	public void GameOver()
    {
        //SceneManager.LoadScene("MenuScene"); // Trở về menu khi game over
        GameOverScreen.SetActive(true);
        if(GameOverScreen != null)
        {
            gameOverPointText.text = "Score: " +playerScore.ToString();
        }
        SaveHighScore(playerScore);
        Time.timeScale = 0f;
        gameOverSound.Play();

    }
    public void SaveHighScore(int score)
    {
        List<int> highScores = new List<int>();

        // Lấy danh sách điểm cũ
        for (int i = 0; i < 10; i++)
        {
            highScores.Add(PlayerPrefs.GetInt("HighScore" + i, 0));
        }

        // Thêm điểm mới vào danh sách
        highScores.Add(score);
        highScores.Sort((a, b) => b.CompareTo(a)); // Sắp xếp giảm dần

        // Chỉ lưu 10 điểm cao nhất
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, highScores[i]);
        }

        PlayerPrefs.Save();
    }

}
