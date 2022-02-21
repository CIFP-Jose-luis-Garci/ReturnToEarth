using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cargarescenajuego()
    {
        SceneManager.LoadScene(1);
    }
    public void cargarescenafinal()
    {
        SceneManager.LoadScene(3);
    }
    public void salir()
    {
        Application.Quit();
    }
}
