using UnityEngine;

public class StarController : MonoBehaviour
{
    public float fallSpeed = 2f; // Tốc độ rơi của Star
    public GameObject sparkleEffect; // Hiệu ứng lấp lánh

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime); // Di chuyển xuống
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag("Player"))
		{
			if (sparkleEffect != null)
			{
				Instantiate(sparkleEffect, transform.position, Quaternion.identity);
			}

			PointBar pointBar = FindObjectOfType<PointBar>();
			if (pointBar != null)
			{
				pointBar.IncreasePoint(1);
			}

			Destroy(gameObject);
		}
	}

	void OnDestroy()
	{
		// Phát âm thanh nổ khi enemy bị hủy
		if (GameManager.instance.deathSound != null)
		{
			AudioSource.PlayClipAtPoint(GameManager.instance.starPickupSound.clip, transform.position);
		}
	}
}
