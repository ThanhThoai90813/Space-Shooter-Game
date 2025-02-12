using UnityEngine;

public class ScrollingRandomBackground : MonoBehaviour
{
    public float speed = 2f; // Tốc độ di chuyển
    public float resetPosition = -10f; // Vị trí reset
    public float startPosition = 10f; // Vị trí bắt đầu lại
    public Sprite[] backgroundSprites; // Danh sách background
    private SpriteRenderer spriteRenderer;

    public float changeDelay = 5f; // Thời gian chờ trước khi đổi background
    private float lastChangeTime; // Thời gian lần cuối đổi background

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeBackground(); // Đổi background khi bắt đầu game
        lastChangeTime = Time.time; // Lưu thời điểm bắt đầu
    }

    void Update()
    {
        // Di chuyển background xuống
        transform.position += Vector3.down * speed * Time.deltaTime;

        // Nếu background xuống quá resetPosition, di chuyển lại vị trí ban đầu
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

    void ChangeBackground()
    {
        if (backgroundSprites.Length > 0)
        {
            int index = Random.Range(0, backgroundSprites.Length);
            spriteRenderer.sprite = backgroundSprites[index];
        }
    }
}
