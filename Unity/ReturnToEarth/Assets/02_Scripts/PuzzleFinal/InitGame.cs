using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    public bool alive;
    public float speed;
    [SerializeField] GameObject reinicio;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        alive = true;
        reinicio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Muerte()
    {
        speed = 0f;
        alive = false;
        GameObject.Find("Nave").SetActive(false);
        Invoke("Reiniciar",2f);
    }
    void Reiniciar()
    {
        reinicio.SetActive(true);
    }
}
