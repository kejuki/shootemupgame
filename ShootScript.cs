using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject bullet;
    AudioSource auds;
    private void Start()
    {
        auds = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            auds.Play();
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
