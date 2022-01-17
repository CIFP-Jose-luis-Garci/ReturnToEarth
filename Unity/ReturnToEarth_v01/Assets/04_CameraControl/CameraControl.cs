using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] GameObject camClonk;
    [SerializeField] GameObject camChakal;
    [SerializeField] GameObject camTrans;
    // Start is called before the first frame update
    void Start()
    {
        camClonk.SetActive(true);
        camChakal.SetActive(false);
        camTrans.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
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
    }
}
