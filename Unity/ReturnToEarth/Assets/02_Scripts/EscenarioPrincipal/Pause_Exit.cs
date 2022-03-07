using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Pause_Exit : MonoBehaviour
{
    //Obtenemos el menu que queremos desactivar/activar
    //Es un Empty Object que actua como padre de los elementos
    [SerializeField] GameObject resumeMenu;
    [SerializeField] GameObject opciones;
    [SerializeField] GameObject start;
    [SerializeField] Button btnStart, btnOptions;
    [SerializeField] GameObject back;
    public AudioMixer mixer;

    //Booleana que nos dice si el juego está pausado o no
    bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos el menú mediante código (en vez de arrastrarlo)
        //IMPORTANTE: Cambiar el nombre del gameobject por el vuestro
        resumeMenu = GameObject.Find("MenuPause");

        //Lo desactivamos de inicio
        resumeMenu.SetActive(false);

        opciones.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //Método que ejecutamos constantemente
        // Podemos cambiarlo por ejemplo por el movimiento de nuestro personaje

        //Si pulsamos la tecla "Esc" o la que sea, se activa el menú
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start"))
        {
            ActivarMenu();
        }

    }


    void ActivarMenu()
    {
        //Interruptor que permite activar y desactivar un menú
        //Si no está pausado, lo pausamos
        if (!gamePaused)
        {
            //EventSystem.current.SetSelectedGameObject(start);
            
            gamePaused = true;
            //Detenemos el tiempo del juego
            Time.timeScale = 0f;
            
        }
        else
        {
            gamePaused = false;
            //Devolvemos el paso del tiempo al juego
            Time.timeScale = 1f;
            opciones.SetActive(false);
        }
        //Lo que haya salido de este interruptor, lo pasamos al menú para que se active o no
        resumeMenu.SetActive(gamePaused);
        print("Se activa el menú");
        btnOptions.Select();
        btnStart.Select();
    }
    //FUNCIONES PARA LOS BOTONES
    public void Resume()
    {
        //Despausamos el juego y ocultamos el menú
        gamePaused = false;
        Time.timeScale = 1f;
        resumeMenu.SetActive(false);
        

    }

    public void Salir()
    {
        Application.Quit();
    }
    public void inicio()
    {
        SceneManager.LoadScene(0);
    }
    public void options()
    {
        resumeMenu.SetActive(false);
        opciones.SetActive(true);
        EventSystem.current.SetSelectedGameObject(back);
    }
    public void volver()
    {
        opciones.SetActive(false);
        resumeMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(start);

    }
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
}