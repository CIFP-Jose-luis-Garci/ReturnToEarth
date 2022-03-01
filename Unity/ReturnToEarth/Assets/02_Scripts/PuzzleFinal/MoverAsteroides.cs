using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAsteroides : MonoBehaviour
{
    float speed;
    InitGame vivir;
    bool vivo;

    void Start()
    {
        vivir = GameObject.FindWithTag("Inicio").GetComponent<InitGame>();
        vivo = vivir.alive;    
    }

    void Update()
    {       
            MovimientoAsteroides();      
    }
    void MovimientoAsteroides()
    {     
            speed = 10f;
            transform.Translate(Vector2.left * Time.deltaTime * speed);
            float posX = transform.position.x;
            if (posX < -15f)
            {
                Destroy(gameObject);
            }       
    }
        
}