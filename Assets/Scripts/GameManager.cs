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

    [Header("Particle Effects")]
    public GameObject explosion;
    public GameObject muzzleFlash;

    [Header("Enemy Speed Settings")]
    public float enemyFallSpeed = 2f; // Tốc độ rơi ban đầu
    public float speedIncreasePerPoint = 0.2f; // Mỗi điểm tăng thêm tốc độ bao nhiêu

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
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
    }

    void InstantiateStar() 
    {
        Vector3 starPos = new Vector3(Random.Range(minInstantiateValue, maxInstantiateValue), 10f);
        GameObject star = Instantiate(starPrefab, starPos, Quaternion.identity);
        Destroy(star, starDestroyTime);
    }
	public void GameOver()
    {
        SceneManager.LoadScene("MenuScene"); // Trở về menu khi game over
    }

}
