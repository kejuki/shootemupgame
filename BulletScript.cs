using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject bullet;
    float speed = 6f;

    void Update()
    {
        if (transform.position.y > 34f)
        {
            Destroy(gameObject);
        }
        bullet.transform.position += new Vector3(0,2,0) * speed * Time.fixedDeltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
