using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float fallSpeed=2f;

    void Update()
    {
       transform.Translate(Vector3.up*fallSpeed*Time.deltaTime);     
    }


}
