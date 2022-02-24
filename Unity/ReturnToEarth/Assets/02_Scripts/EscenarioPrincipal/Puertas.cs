using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public GameObject[] puertas;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       puertas = GameObject.FindGameObjectsWithTag("puertas");
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Personajes")
        {
            animator.SetBool("Open", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Personajes" )
        { 
            animator.SetBool("Open", false);
        }
    }
}
