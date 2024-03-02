using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWONE : MonoBehaviour
{
    public float speed = 7;
    float turboSpeed = 17;
    float cuurentSpeed;
    public Color turboColor;
    private Color defaultColor;
    public SpriteRenderer sr;

    private Object lastItemCollidedWith;

    // Start is called before the first frame update
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            cuurentSpeed = turboSpeed;
            sr.color = turboColor;
        }
        else
        {
            cuurentSpeed = speed;
            sr.color = defaultColor;
        }


        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        transform.Translate(xMove * cuurentSpeed * Time.deltaTime, yMove * cuurentSpeed * Time.deltaTime, 0.0f);

    }
    /*
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Debug.Log("WE COLLIDED BROOOOOOOOOOOOO");
            lastItemCollidedWith = collision.gameObject.GetComponent<Object>();
            Color tempColor = collision.gameObject.GetComponent<Object>().ObjectColor;
            sr.color = defaultColor;
            Destroy(collision.gameObject);


        }

    }
    */
}