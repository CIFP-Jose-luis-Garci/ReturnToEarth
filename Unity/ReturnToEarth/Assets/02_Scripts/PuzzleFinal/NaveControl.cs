using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveControl : MonoBehaviour
{
    Rigidbody2D rb;
    InitGame vivir;
    bool vivo;
    public GameObject boom;
    float desplY;
    float speed;
    float limiteV1 = 4.4f;
    float limiteV2 = -4.40f;
    void Start()
    {
        vivir = GameObject.FindWithTag("Inicio").GetComponent<InitGame>();
        vivo = vivir.alive;  
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (vivo)
        {
            NavegarY();
        }
        desplY = Input.GetAxis("Vertical");
    }
    void NavegarY()
    {
        speed = vivir.speed;
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
            Instantiate(boom, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        else if(other.gameObject.tag == "Final")
        {
            //cargar cinematica
        }
    }
}


