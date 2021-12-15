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
        maxSpeed = 4f;
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
    private void FixedUpdate()
    {
      
    }

    void MoverAbajo()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, desplY * maxSpeed);
            animator.SetBool("Caminar_Abajo",true);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(0f, 0f);
            animator.SetBool("Caminar_Abajo",false);
        } 
    }
    void MoverArriba()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, desplY * maxSpeed);
            animator.SetBool("Caminar_Arriba", true);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(0f, 0f);
            animator.SetBool("Caminar_Arriba", false);
        }    
    }
    void MoverIzquierda()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(desplX * maxSpeed, rb.velocity.y);
            animator.SetBool("Caminar_Izquierda", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(0f, 0f);
            animator.SetBool("Caminar_Izquierda", false);
        }   
    }
    void MoverDerecha()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(desplX * maxSpeed, rb.velocity.y);
            animator.SetBool("Caminar_Derecha", true);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(0f, 0f);
            animator.SetBool("Caminar_Derecha", false);
        }
    }


}
