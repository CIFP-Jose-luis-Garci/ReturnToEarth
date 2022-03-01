using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCajas : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = 10000000f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Clonk")
        {
            rb.mass = 100f;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Clonk")
        {
            rb.mass = 10000000f;
        }
    }
}
