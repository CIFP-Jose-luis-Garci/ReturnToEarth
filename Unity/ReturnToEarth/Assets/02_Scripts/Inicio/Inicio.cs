using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Inicio : MonoBehaviour
{
    [SerializeField] GameObject opciones;
    [SerializeField] GameObject botones;
    [SerializeField] GameObject start;
    [SerializeField] GameObject back;


    // Start is called before the first frame update
    void Start()
    {
        opciones.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cargarescenajuego()
    {
        SceneManager.LoadScene(4);
    }
    public void cargarescenafinal()
    {
        SceneManager.LoadScene(3);
    }
    public void salir()
    {
        Application.Quit();
    }
    public void cargarescenaprincipal()
    {
        SceneManager.LoadScene(0);
    }
    public void options()
    {
        opciones.SetActive(true);
        botones.SetActive(false);
        EventSystem.current.SetSelectedGameObject(back);
    }
    public void volver()
    {
        opciones.SetActive(false);
        botones.SetActive(true);
        EventSystem.current.SetSelectedGameObject(start);
    }

}
