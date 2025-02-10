using UnityEngine;

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

    [Header("Panels")]
    public GameObject startMenu;
    public GameObject pauseMenu;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        startMenu.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
        InvokeRepeating("InstantiateEnemy", 1f, 2f);
        InvokeRepeating("InstantiateStar", 1f, 3f); // Star xuất hiện mỗi 3 giây

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(true);
        }
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


    public void StartButtion()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame(bool isPaused)
    {
        if (isPaused == true)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        } else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
       
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
