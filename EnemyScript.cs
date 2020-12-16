using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{
    public GameObject player;

    Rigidbody2D rb;
    SpriteRenderer sp;
    BoxCollider2D bc;

    GameObject EventObj;
    EventScript es;
    Vector2 playerPos;
    AudioSource auds;
    float speed = 5f;
    int direction;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        auds = GetComponent<AudioSource>();

        EventObj = GameObject.FindWithTag("EventObj");
        es = EventObj.GetComponent<EventScript>();
        transform.position = new Vector2(Random.Range(-30f, 30f), 35);
        direction = Random.Range(0, 2);
    }

    private void FixedUpdate()
    {
        //movement
        if (transform.position.x > 32.0f) { direction = 0; }
        if (transform.position.x < -32.0f) { direction = 1; }

        transform.position += -transform.up * speed * Time.deltaTime;
        if (direction == 1) {transform.position += transform.right * speed * Time.deltaTime;}
        else {transform.position += -transform.right * speed * Time.deltaTime;}
        
        //player = GameObject.FindWithTag("Player");
        //playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        //transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.fixedDeltaTime);

        if (transform.position.y < -30)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(Death());
        }
    }
    IEnumerator Death()
    {
        //delayed death so audio gets to play before the object is gone
        Destroy(rb);
        bc.enabled = false;
        sp.enabled = false;
        auds.Play();
        es.IncreaseScore();
        yield return new WaitForSeconds(auds.clip.length);
        Destroy(gameObject);
    }
}
