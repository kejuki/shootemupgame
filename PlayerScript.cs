using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    GameObject EventObj;
    EventScript es;

    Rigidbody2D rb;
    Vector2 move;
    Vector2 respawn = new Vector2(0, -10);
    public GameObject player;
    public GameObject gun;
    float speed = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = respawn;

        //accessing eventscript to call its functions
        EventObj = GameObject.FindWithTag("EventObj");
        es = EventObj.GetComponent<EventScript>();
    }

    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + move.normalized * speed * Time.fixedDeltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //player death
        if(collision.gameObject.tag == "Enemy")
        {
            transform.position = respawn;
            es.ResetScore();
            es.KillEnemies();
        }
    }
}
