using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    [Header("Missile")]
    public GameObject missile;
    public Transform missileSpawnPosition;
    public float destroyTimes =5f;

    private void Update()
    {
        PlayerMovement();
        PlayerShoot();
    }

    void PlayerMovement()
    {
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xPos, yPos, 0) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject gm = Instantiate(missile, missileSpawnPosition);
            gm.transform.SetParent(null);
            Destroy(gm, destroyTimes);   
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject gm = Instantiate(GameManager.instance.explosion, transform
               .position, transform.rotation);
            Destroy(gm, 2f);
            Destroy(this.gameObject);
            //game over screen will appear here
        }
    }

}
