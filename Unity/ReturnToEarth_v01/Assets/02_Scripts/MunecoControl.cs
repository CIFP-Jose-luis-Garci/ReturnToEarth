using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunecoControl : MonoBehaviour
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
        desplX = Input.GetAxis("Horizontal");
        desplY = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        caminarX();
        caminarY();
    }
    void caminarX()
    {
        rb.velocity = new Vector2(desplX * maxSpeed, rb.velocity.y);
        speed = rb.velocity.x;
        animator.SetFloat("SpeedX", Mathf.Abs(speed));
        if(speed >= 4f)
        {
            animator.SetBool("Caminar_Izquierda", false);
            animator.SetBool("Caminar_Derecha", true);
        }
        else if(speed <= -4f)
        {
            animator.SetBool("Caminar_Derecha", false);
            animator.SetBool("Caminar_Izquierda", true);
        }
        else
        {
            animator.SetBool("Caminar_Derecha", false);
            animator.SetBool("Caminar_Izquierda", false);
        }
    }
    void caminarY()
    {
        rb.velocity = new Vector2(rb.velocity.x, desplY * maxSpeed);
        speed = rb.velocity.y;
        animator.SetFloat("SpeedY", Mathf.Abs(speed));
        if (speed >= 4f)
        {
            animator.SetBool("Caminar_Abajo", false);
            animator.SetBool("Caminar_Arriba", true);
        }
        else if (speed <= -4f)
        {
            animator.SetBool("Caminar_Arriba", false);
            animator.SetBool("Caminar_Abajo", true);
        }
        else
        {
            animator.SetBool("Caminar_Arriba", false);
            animator.SetBool("Caminar_Abajo", false);
        }
    }

}
