using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDeleter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject); // Destroy the coin
        }
        if (other.gameObject.CompareTag("Transition"))
        {
            Destroy(other.gameObject); // destroy froggy
        }
        if (other.gameObject.CompareTag("Hazard"))
        {
            Destroy(other.gameObject); // destroy duck
        }
    }

}
