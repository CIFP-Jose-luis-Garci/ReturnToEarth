using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCH : MonoBehaviour
{
    //Personajes
    /*
     * 0- Nemea
     * 1- Viktor
     * 2- Clonk
     * 3- Chakal
    */

    //Array que contendrá a los personajes
    [SerializeField] GameObject[] chars = new GameObject[4];
    //Array que contendra los scripts de control
    MunecoControl[] charCtrl = new MunecoControl[4];
    //Array que contendrás las cámaras, más la de transición
    [SerializeField] GameObject[] charCams = new GameObject[4];
    //Array con los sprites de selección y los básicos
    [SerializeField] Sprite[] menuSelected = new Sprite[4];
    [SerializeField] Sprite[] menuNotSelected = new Sprite[4];
    //Array con las imágenes de selección
    [SerializeField] Image[] menuImages = new Image[4];
    [SerializeField] GameObject camTrans;
    //Menú para elegir personaje
    [SerializeField] GameObject menuCH;
    [SerializeField] GameObject inventario;
    [SerializeField] GameObject objetivos;
    bool menuCHactive = false;
    bool inventarioactive = false;
    //Si se ha seleccionado ya al personaje
    bool chSeleceted = false;
    


    //Personaje activo ahora mismo. Deberíamos obtrenerlo del Game Manager
    //Es un INT, para que se corresponda con los arrays
    int activeCH = 2;

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

        //Ponemos la imagen del personaje seleccionado
        menuImages[activeCH].sprite = menuSelected[activeCH];

        //Desactivamos el menú
        menuCH.SetActive(false);
        //Desactivamos el inventario
        inventario.SetActive(false);
        //Desactivamos los objetivos
        objetivos.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C) || Input.GetButtonDown("Fire3"))
        {
            
            //Mostramos el menú si no está activo
            if(!menuCHactive)
            {
                menuCH.SetActive(true);
                menuCHactive = true;
                objetivos.SetActive(true);

                //Desactivamos el desplazamiento
                
            }
            else
            {
                menuCH.SetActive(false);
                menuCHactive = false;
                objetivos.SetActive(false);
                //Activamos de nuevo el desplazamiento
                charCtrl[activeCH].enabled = true;
            }
        }
        /*Inventario
        if (Input.GetKeyDown(KeyCode.I) || Input.GetButtonDown("Fire2"))
        {
            if (!inventarioactive)
            {
                inventario.SetActive(true);
                inventarioactive = true;
            }
            else
            {
                inventario.SetActive(false);
                inventarioactive = false;
            }
           
        }
        */
            //Si el menú está activo
            if (menuCHactive)
        {
            float DpadH = Input.GetAxis("DPad_H");
            float DpadV = Input.GetAxis("DPad_V");

            

            //Pulsamos el personaje 1
            if((DpadV == 1 && activeCH != 1) || (Input.GetKeyDown(KeyCode.UpArrow) && activeCH != 1))
            {
                if(!chSeleceted)
                {
                    ChangeChar(1);
                    chSeleceted = true;
                    inventario.GetComponent<Image>().color = new Color (255,177,67);
                }
                
            }
            else if ((DpadH == 1 && activeCH != 2) || (Input.GetKeyDown(KeyCode.RightArrow) && activeCH != 2))
            {
                if (!chSeleceted)
                {
                    ChangeChar(2);
                    chSeleceted = true;
                    inventario.GetComponent<Image>().color = new Color (0,163,255);
                }
            }
            else if ((DpadV == -1 && activeCH != 3) || (Input.GetKeyDown(KeyCode.DownArrow) && activeCH != 3))
            {
                if (!chSeleceted)
                {
                    ChangeChar(3);
                    chSeleceted = true;
                    inventario.GetComponent<Image>().color = new Color (228,34,50);
                }
            }
            else if ((DpadH == -1 && activeCH != 0) || (Input.GetKeyDown(KeyCode.LeftArrow) && activeCH != 0))
            {
                if (!chSeleceted)
                {
                    ChangeChar(0);
                    chSeleceted = true;
                    inventario.GetComponent<Image>().color = new Color (47,237,155);
                }
            }
        }
    }

    public void ChangeChar(int newChar)
    {
        
        menuCHactive = false;
        //Desactivamos la cámara y activamos la de transición
        charCams[activeCH].SetActive(false);
        camTrans.SetActive(true);
        //Desactivamos el control del personaje y activamos el nuevo
        charCtrl[activeCH].enabled = false;
        //Desactivamos el box collider para que no haya bug con los triggers de las estancias
        charCtrl[activeCH].GetComponent<BoxCollider2D>().enabled = false;
        charCtrl[newChar].enabled = true;
        //Activamos el box collider para que no haya bug con los triggers de las estancias
        charCtrl[newChar].GetComponent<BoxCollider2D>().enabled = true;


        //Quitamos el botón del seleccionado y ponemos el nuevo
        menuImages[activeCH].sprite = menuNotSelected[activeCH];
        menuImages[newChar].sprite = menuSelected[newChar];

        //Alternamos personaje
        activeCH = newChar;
        //Llamamos al personaje
        Invoke("GoToCamera", 1f);

    }

    public void GoToCamera()
    {
        //Desactivamos el menú
        menuCH.SetActive(false);
        //Volvemos a poner que el personaje esta por seleccionar
        chSeleceted = false;
        //Activamos la cámara del personaje
        camTrans.SetActive(false);
        charCams[activeCH].SetActive(true);

    }
}
