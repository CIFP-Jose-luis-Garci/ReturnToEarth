using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapas : MonoBehaviour
{
    public int contador;
    public Text puntuacion;
    [SerializeField] GameObject contadore;
    // Start is called before the first frame update
    void Start()
    {
        contadore.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void contadormapas()
    {
        puntuacion.text = contador + "/4";
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
            Invoke("ocultar", 5f);
        }
    }
}
