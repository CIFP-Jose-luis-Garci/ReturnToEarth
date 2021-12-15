using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunecooControl : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    float desplY;
    float desplX;
    float speed;
    Animator animator;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = 4f;
        

    }

    // Update is called once per frame
    void Update()
    {
        MoverAbajo();
        MoverArriba();
        MoverDerecha();
        MoverIzquierda();
        desplX = Input.GetAxis("Horizontal");
        desplY = Input.GetAxis("Vertical");
    }

    void MoverAbajo()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("Caminar_Abajo",true);
            rb.velocity = new Vector2(desplY * maxSpeed, rb.velocity.x);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("Caminar_Abajo",false);
        }
        speed = rb.velocity.y;
    }
    void MoverArriba()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("Caminar_Arriba", true);
            rb.velocity = new Vector2(desplY * maxSpeed, rb.velocity.x);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("Caminar_Arriba", false);
        }
        speed = rb.velocity.y;
    }
    void MoverIzquierda()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("Caminar_Izquierda", true);
            rb.velocity = new Vector2(desplX * maxSpeed, rb.velocity.y);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("Caminar_Izquierda", false);
        }
        speed = rb.velocity.x;
    }
    void MoverDerecha()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("Caminar_Derecha", true);
            rb.velocity = new Vector2(desplX * maxSpeed, rb.velocity.y);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("Caminar_Derecha", false);
        }
        speed = rb.velocity.x;
    }


}
