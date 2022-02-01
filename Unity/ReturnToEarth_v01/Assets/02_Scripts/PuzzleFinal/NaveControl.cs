using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveControl : MonoBehaviour
{
    Rigidbody2D rb;
    InitGame vivir;
    bool vivo;
    float desplY;
    float speed;
    float limiteV1 = 4.38f;
    float limiteV2 = -4.40f;
    void Start()
    {
        vivir = GameObject.FindWithTag("Inicio").GetComponent<InitGame>();
        vivo = vivir.alive;
        speed = vivir.speed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        desplY = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        if (vivir.alive)
        {
            NavegarY();
        }   
    }
    void NavegarY()
    {
        float posY = transform.position.y;
        float desplY = Input.GetAxis("Vertical") * speed;
        if ((posY < limiteV1 || desplY < 0f) && (posY > limiteV2 || desplY > 0f))
        {
            transform.Translate(Vector3.up * desplY * Time.deltaTime);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Asteroides")
        {
            InitGame initGame = GameObject.FindWithTag("Inicio").GetComponent<InitGame>();
            initGame.SendMessage("Muerte");
        }
    }
    
}


