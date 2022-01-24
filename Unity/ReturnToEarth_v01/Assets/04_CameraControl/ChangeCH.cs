using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCH : MonoBehaviour
{
    //Personajes
    /*
     * 0 - Clonk
     * 1- Chakal
     * 2- 
     * 3- 
    */

    //Array que contendrá a los personajes
    [SerializeField] GameObject[] chars = new GameObject[4];

    //Array que contendra los scripts de control
    MunecoControl[] charCtrl = new MunecoControl[4];

    //Array que contendrás las cámaras, más la de transición
    [SerializeField] GameObject[] charCams = new GameObject[4];
    [SerializeField] GameObject camTrans;

    //Menú para elegir personaje
    [SerializeField] Image menuCH;
    bool menuCHactive = false;
    //Array con los sprites
    [SerializeField] Sprite[] menuCHsprites;


    //Personaje activo ahora mismo. Deberíamos obtrenerlo del Game Manager
    //Es un INT, para que se corresponda con los arrays
    int activeCH = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos los componentes de scripts
        for(int n = 0; n < 4; n++)
        {
            charCtrl[n] = chars[n].GetComponent<MunecoControl>();
            //Si no es el del jugador controlado, lo desactivamos, y su cámara
            if(n != activeCH)
            {
                charCtrl[n].enabled = false;
                charCams[n].SetActive(false);
            }
        }

        //Activamos la cámara de nuestro personaje y desactivamos la de transiciín
        camTrans.SetActive(false);
        charCams[activeCH].SetActive(true);
        

        //Desactivamos el menú
        menuCH.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            //print("cambiando");
            //Mostramos el menú si no está activo
            if(!menuCHactive)
            {
                menuCH.enabled = true;
                menuCHactive = true;
                //Desactivamos el desplazamiento
                //charCtrl[activeCH].enabled = false;
            }
            else
            {
                menuCH.enabled = false;
                menuCHactive = false;
                //Activamos de nuevo el desplazamiento
                charCtrl[activeCH].enabled = true;
            }
            

        }

        //Si el menú está activo
        if(menuCHactive)
        {
            //Pulsamos el personaje 1
            if(Input.GetKeyDown(KeyCode.Keypad0) && activeCH != 0)
            {
                ChangeChar(0);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad1) && activeCH != 1)
            {
                ChangeChar(1);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2) && activeCH != 2)
            {
                ChangeChar(2);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3) && activeCH != 3)
            {
                ChangeChar(3);
            }
        }
    }

    public void ChangeChar(int newChar)
    {
        //Desactivamos el menú
        menuCH.enabled = false;
        menuCHactive = false;
        //Desactivamos la cámara y activamos la de transición
        charCams[activeCH].SetActive(false);
        camTrans.SetActive(true);
        //Desactivamos el control del personaje y activamos el nuevo
        charCtrl[activeCH].enabled = false;
        charCtrl[newChar].enabled = true;
        //Alternamos personaje
        activeCH = newChar;
        //Llamamos al personaje
        Invoke("GoToCamera", 1f);

    }

    public void GoToCamera()
    {
        //print("cambiando de camara");
        //Activamos la cámara del personaje
        camTrans.SetActive(false);
        charCams[activeCH].SetActive(true);

    }
}
