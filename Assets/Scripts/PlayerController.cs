using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    [Header("Missile")]
    public GameObject missile;
    public Transform missileSpawnPosition;
    public float destroyTimes =5f;
    public Animator animator;
    public Transform muzzleSpawnPosition;
    public AudioSource lazerSound, deathSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerMovement();
        PlayerShoot();
    }

    void PlayerMovement()
    {
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");

        bool isMoving = (xPos != 0 || yPos != 0);
        animator.SetBool("isMoving", isMoving);

        Vector3 movement = new Vector3(xPos, yPos, 0) * speed * Time.deltaTime;
        transform.Translate(movement);
        LimitPlayerPosition();
    }

    void LimitPlayerPosition()
    {
        // Lấy Camera chính
        Camera cam = Camera.main;

        // Giới hạn góc trái dưới và góc phải trên trong thế giới (World Space)
        Vector3 minBounds = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)); // Góc trái dưới
        Vector3 maxBounds = cam.ViewportToWorldPoint(new Vector3(1, 1, 0)); // Góc phải trên

        // Lấy vị trí hiện tại của Player
        Vector3 clampedPosition = transform.position;

        // Giới hạn theo biên của camera
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minBounds.x, maxBounds.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minBounds.y, maxBounds.y);

        // Cập nhật vị trí mới
        transform.position = clampedPosition;
    }


    void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnMissile();
            SpawnMuzzleFlash();
        }
    }
    void SpawnMissile()
    {
        GameObject gm = Instantiate(missile, missileSpawnPosition);
        gm.transform.SetParent(null);
        Destroy(gm, destroyTimes);
    }
    void SpawnMuzzleFlash()
    {
        GameObject muzzle = Instantiate(GameManager.instance.muzzleFlash, muzzleSpawnPosition);
        muzzle.transform.SetParent(null);
		lazerSound.Play();
		Destroy(muzzle, destroyTimes);
    }

	IEnumerator PlayDeathSoundAndDestroy()
	{
		deathSound.Play();
		yield return new WaitForSeconds(deathSound.clip.length);
		Destroy(this.gameObject);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			GameObject gm = Instantiate(GameManager.instance.explosion, transform.position, transform.rotation);
			StartCoroutine(PlayDeathSoundAndDestroy());
			GameManager.instance.GameOver();
		}
	}


}
