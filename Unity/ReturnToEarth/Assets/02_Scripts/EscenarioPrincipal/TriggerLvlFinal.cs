using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLvlFinal : MonoBehaviour
{
    [SerializeField] GameObject cartel;
    // Start is called before the first frame update
    void Start()
    {
        cartel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Clonk")
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            cartel.SetActive(true);
            Invoke("desaparecer", 3f);
        }
    }
    public void desaparecer()
    {
        cartel.SetActive(false);
    }
}
