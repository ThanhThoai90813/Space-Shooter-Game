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

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InvokeRepeating("InstantiateEnemy", 1f, 2f);
        InvokeRepeating("InstantiateStar", 1f, 3f);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    PauseGame(true);
        //}
    }

    void InstantiateEnemy()
    {
        Vector3 enemypos = new Vector3(Random.Range(minInstantiateValue, maxInstantiateValue), 6f);
        GameObject enemy = Instantiate(enemyPrefab, enemypos, Quaternion.Euler(0f,0f,180f));
        Destroy(enemy, enemyDestroyTime);
    }

    void InstantiateStar() 
    {
        Vector3 starPos = new Vector3(Random.Range(minInstantiateValue, maxInstantiateValue), 6f);
        GameObject star = Instantiate(starPrefab, starPos, Quaternion.identity);
        Destroy(star, starDestroyTime);
    }
    public void GameOver()
    {
        SceneManager.LoadScene("MenuScene"); // Trở về menu khi game over
    }

}
