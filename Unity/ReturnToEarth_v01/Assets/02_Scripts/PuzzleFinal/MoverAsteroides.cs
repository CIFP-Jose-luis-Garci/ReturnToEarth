using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAsteroides : MonoBehaviour
{
    float speed;
    InitGame vivir;
    bool alive;

    void Start()
    {
        vivir = GameObject.FindWithTag("Inicio").GetComponent<InitGame>();
        alive = vivir.alive;    
    }

    void Update()
    {
        if (alive)
        {
            MovimientoAsteroides();
        }
       
    }
    void MovimientoAsteroides()
    {
        speed = 5f;
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        float posX = transform.position.x;
        if (posX < -15f)
        {
            Destroy(gameObject);
        }
    }
}