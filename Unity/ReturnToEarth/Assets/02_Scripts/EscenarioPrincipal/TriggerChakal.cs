using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerChakal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Chakal")
        {
            SceneManager.LoadScene(2);
        }
        else
        {
           //Poner cartel de que debes seleccionar a chakal para pasar por ahi
        }
    }
    
}
