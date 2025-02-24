using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float fallSpeed=2f;
    private SpriteRenderer spriteRenderer;

    [Header("Enemy Appearance")]
    public Sprite[] enemySprite;

    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
        if(enemySprite.Length > 0)
        {
            //chọn random 1 sprite từ enemySprites
            spriteRenderer.sprite = enemySprite[Random.Range(0,enemySprite.Length)];
        }

        //random kích thước
        float randomSize = Random.Range(0.9f, 2f);
        transform.localScale = new Vector3(randomSize, randomSize, 1);
    }

    void Update()
    {
       transform.Translate(Vector3.up*fallSpeed*Time.deltaTime);     
    }

	void OnDestroy()
	{
		// Phát âm thanh nổ khi enemy bị hủy
		if (GameManager.instance.deathSound != null)
		{
			AudioSource.PlayClipAtPoint(GameManager.instance.deathSound.clip, transform.position);
		}
	}
}
