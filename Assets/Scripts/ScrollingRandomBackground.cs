using UnityEngine;

public class ScrollingRandomBackground : MonoBehaviour
{
    public float baseSpeed = 2f;  
    private float currentSpeed;   
    public float speedIncreasePerPoint = 0.1f; 
    public float resetPosition = -10f;
    public float startPosition = 10f;

    public Sprite[] backgroundSprites; 
    private SpriteRenderer spriteRenderer;

    public float changeDelay = 5f; 
    private float lastChangeTime; 

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentSpeed = baseSpeed;  
        ChangeBackground(); 
        lastChangeTime = Time.time; 
    }

    private void Update()
    {
        transform.position += Vector3.down * currentSpeed * Time.deltaTime;

        if (transform.position.y <= resetPosition)
        {
            transform.position = new Vector3(transform.position.x, startPosition, transform.position.z);

            // Chỉ đổi background nếu đủ thời gian chờ
            if (Time.time - lastChangeTime >= changeDelay)
            {
                ChangeBackground();
                lastChangeTime = Time.time; // Cập nhật lại thời điểm đổi background
            }
        }
    }

    public void IncreaseSpeed(int score)
    {
        currentSpeed = baseSpeed + (score * speedIncreasePerPoint);
    }

    void ChangeBackground()
    {
        if (backgroundSprites.Length > 0)
        {
            int index = Random.Range(0, backgroundSprites.Length);
            spriteRenderer.sprite = backgroundSprites[index];
        }
    }
}
