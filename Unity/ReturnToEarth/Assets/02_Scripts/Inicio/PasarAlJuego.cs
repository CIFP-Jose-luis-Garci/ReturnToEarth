using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarAlJuego : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("pasaraljuego",124f);
    }
    void pasaraljuego()
    {
        SceneManager.LoadScene(1);
    }
}
