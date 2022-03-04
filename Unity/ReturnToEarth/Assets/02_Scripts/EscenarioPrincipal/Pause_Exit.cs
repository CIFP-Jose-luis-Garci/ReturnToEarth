using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Exit : MonoBehaviour
{
    //Obtenemos el menu que queremos desactivar/activar
    //Es un Empty Object que actua como padre de los elementos
    [SerializeField] GameObject resumeMenu;

    //Booleana que nos dice si el juego est� pausado o no
    bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos el men� mediante c�digo (en vez de arrastrarlo)
        //IMPORTANTE: Cambiar el nombre del gameobject por el vuestro
        resumeMenu = GameObject.Find("MenuPause");

        //Lo desactivamos de inicio
        resumeMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //M�todo que ejecutamos constantemente
        // Podemos cambiarlo por ejemplo por el movimiento de nuestro personaje

        //Si pulsamos la tecla "Esc" o la que sea, se activa el men�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ActivarMenu();
        }

    }


    void ActivarMenu()
    {
        //Interruptor que permite activar y desactivar un men�
        //Si no est� pausado, lo pausamos
        if (!gamePaused)
        {
            gamePaused = true;
            //Detenemos el tiempo del juego
            Time.timeScale = 0f;
        }
        else
        {
            gamePaused = false;
            //Devolvemos el paso del tiempo al juego
            Time.timeScale = 1f;
        }
        //Lo que haya salido de este interruptor, lo pasamos al men� para que se active o no
        resumeMenu.SetActive(gamePaused);
    }
    //FUNCIONES PARA LOS BOTONES
    public void Resume()
    {
        //DESpausamos el juego y ocultamos el men�
        gamePaused = false;
        Time.timeScale = 1f;
        resumeMenu.SetActive(false);

    }

    public void Salir()
    {
        //Esta l�nea de c�digo hace que se salga del juego
        //ES MUY IMPORTANTE DAR A LOS JUGADORES LA OPCi�N DE SALIR
        Application.Quit();
    }
}