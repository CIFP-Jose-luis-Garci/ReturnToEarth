using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonkController : MonoBehaviour
{
    float speed;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4f;
        Movimientosesy();

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    void Movimientosesy()
    {
        if (Input.GetKeyDown(KeyCode.Space) && animator.GetBool("Caminar_Arriba"))
        {
            float desplY = Input.GetAxis("Vertical") * speed;
        }
    }


}
