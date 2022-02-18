using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MunecoControl : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] GameObject contadore;
    float desplY;
    float desplX;
    float speed;
    public int contador;
    public Text puntuacion;
    Animator animator;
    Rigidbody2D rb;
    public GameObject[] estancias = new GameObject [7];
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        maxSpeed = 4f;
        contadore.SetActive(false);
        estancias[0].SetActive(false);
        estancias[1].SetActive(false);
        estancias[2].SetActive(false);
        estancias[3].SetActive(false);
        estancias[4].SetActive(false);
        estancias[5].SetActive(false);
        estancias[6].SetActive(false);
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
        if(speed >= 0.01f)
        {
            animator.SetBool("Caminar_Arriba", false);
            animator.SetBool("Caminar_Abajo", false);
            animator.SetBool("Caminar_Izquierda", false);
            animator.SetBool("Caminar_Derecha", true);
        }
        else if(speed <= -0.01f)
        {
            animator.SetBool("Caminar_Arriba", false);
            animator.SetBool("Caminar_Abajo", false);
            animator.SetBool("Caminar_Derecha", false);
            animator.SetBool("Caminar_Izquierda", true);
        }     
    }
    void caminarY()
    {
        rb.velocity = new Vector2(rb.velocity.x, desplY * maxSpeed);
        speed = rb.velocity.y;
        animator.SetFloat("SpeedY", Mathf.Abs(speed));
        if (speed >= 0.01f)
        {
            animator.SetBool("Caminar_Izquierda", false);
            animator.SetBool("Caminar_Derecha", false);
            animator.SetBool("Caminar_Abajo", false);
            animator.SetBool("Caminar_Arriba", true);
        }
        else if (speed <= -0.01f)
        {
            animator.SetBool("Caminar_Izquierda", false);
            animator.SetBool("Caminar_Derecha", false);
            animator.SetBool("Caminar_Arriba", false);
            animator.SetBool("Caminar_Abajo", true);
        }        
    }
    public void contadormapas()
    {
        puntuacion.text = contador + "/4" ;
    }
    void ocultar()
    {
        contadore.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "mapa")
        {
            Destroy(other.gameObject);
            contador = contador + 1;
            contadormapas();
            contadore.SetActive(true);
            Invoke("ocultar", 3f);
        }
        else if(other.gameObject.tag == "PuenteMandos")
        {
            estancias[0].SetActive(true);
        }
        else if (other.gameObject.tag == "SistemaVentilacion")
        {
            estancias[1].SetActive(true);
        }
        else if (other.gameObject.tag == "SalaMaquinas")
        {
            estancias[2].SetActive(true);
        }
        else if (other.gameObject.tag == "ZonaComun")
        {
            estancias[3].SetActive(true);
        }
        else if (other.gameObject.tag == "SalaControl")
        {
            estancias[4].SetActive(true);
        }
        else if (other.gameObject.tag == "HabitacionChakal")
        {
            estancias[5].SetActive(true);
        }
        else if (other.gameObject.tag == "HabitacionNemea")
        {
            estancias[6].SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "PuenteMandos")
        {
            estancias[0].SetActive(false);
        }
        else if (other.gameObject.tag == "SistemaVentilacion")
        {
            estancias[1].SetActive(false);
        }
        else if (other.gameObject.tag == "SalaMaquinas")
        {
            estancias[2].SetActive(false);
        }
        else if (other.gameObject.tag == "ZonaComun")
        {
            estancias[3].SetActive(false);
        }
        else if (other.gameObject.tag == "SalaControl")
        {
            estancias[4].SetActive(false);
        }
        else if (other.gameObject.tag == "HabitacionChakal")
        {
            estancias[5].SetActive(false);
        }
        else if (other.gameObject.tag == "HabitacionNemea")
        {
            estancias[6].SetActive(false);
        }
    }
}


