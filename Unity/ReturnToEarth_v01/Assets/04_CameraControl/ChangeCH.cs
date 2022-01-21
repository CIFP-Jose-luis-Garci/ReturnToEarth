using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCH : MonoBehaviour
{
    //Personajes
    [SerializeField] GameObject Clonk;
    [SerializeField] GameObject Chakal;

    MunecoControl ClonkCtrl;
    MunecoControl ChakalCtrl;

    //Camaras
    [SerializeField] GameObject camClonk;
    [SerializeField] GameObject camChakal;
    [SerializeField] GameObject camTrans;

    //Menú para elegir personaje
    [SerializeField] Image menuCH;
    //Array con los sprites
    [SerializeField] Sprite[] menuCHsprites;

    bool menuChActive = false;

    //Personaje activo ahora mismo. Deberíamos obtrenerlo del Game Manager
    GameObject activeCH;

    // Start is called before the first frame update
    void Start()
    {
        ClonkCtrl = Clonk.GetComponent<MunecoControl>();
        ChakalCtrl = Chakal.GetComponent<MunecoControl>();

        //Desactivamos los controles de los otros jugadores
        ChakalCtrl.enabled = false;

        //Desativamos cámaras
        camClonk.SetActive(true);
        camChakal.SetActive(false);
        camTrans.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //print("cambiando");


            camTrans.SetActive(true);
            camClonk.SetActive(false);

            Invoke("GoToCamera", 1f);

        }
    }

    public void GoToCamera()
    {
        print("cambiando de camara");
        camChakal.SetActive(true);
        camTrans.SetActive(false);

        //Desactivamos el personaje y activamos el otro
        ChakalCtrl.enabled = true;
        ClonkCtrl.enabled = false;

    }
}
