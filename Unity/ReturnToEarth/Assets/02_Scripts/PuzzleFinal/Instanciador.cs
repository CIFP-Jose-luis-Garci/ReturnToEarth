using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{

    float intervalo;
    [SerializeField] GameObject[] asteroides;
    [SerializeField] Transform instantiatePos;
    [SerializeField] float distance;
    bool vivo;
    void Start()
    {
        distance = 5f;
        StartCoroutine("CrearAsteroides");              
    }
    void Update()
    {

    }
    IEnumerator CrearAsteroides()
    {
        
            float speed;
            while (true)
            {
                speed = 5f;
                intervalo = distance / speed;
                float randomY = Random.Range(5f, -5f);
                Vector2 newPos = new Vector3(instantiatePos.position.x + 5f, randomY);
                int numAl = Random.Range(0, asteroides.Length);
                Instantiate(asteroides[numAl], newPos, Quaternion.identity);
                yield return new WaitForSeconds(intervalo);
            }
        
            
    }
}