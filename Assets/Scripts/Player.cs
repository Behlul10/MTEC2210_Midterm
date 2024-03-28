using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public float speed;
    public float turboSpeed;
    public float currentSpeed;
    //public AudioClip clip;
    //AudioSource audiosource;

    // Start is called before the first frame update

    private void Start()
    {
        //audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame


    void Update()
    {
        if (Input.GetKey(KeyCode.J)) 
        {
            currentSpeed = turboSpeed;
            //sr.color = turboColor;
        }
        else
        {
            currentSpeed = speed;
            //sr.color = Color.White;
        }

        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        transform.Translate(xMove * currentSpeed * Time.deltaTime, yMove * currentSpeed * Time.deltaTime, 0);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            //audioSource.PlayOneShot(clip);
        }
    }
}
