using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MovimientoChakal : MonoBehaviour
{
    float speed = 30f;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
      audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        NavegarY();
        NavegarX();
    }
    void NavegarY()
    {
        float posY = transform.position.y;
        float desplY = Input.GetAxis("Vertical") * speed;
        transform.Translate(Vector3.up * desplY * Time.deltaTime);
    }
    void NavegarX()
    {
        float posX = transform.position.x;
        float desplX = Input.GetAxis("Horizontal") * speed;
        transform.Translate(Vector3.right * desplX * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "galleta")
        {
            Destroy(other.gameObject);
            PlaySound();
        }
    }
    public void PlaySound()
    {
        audioSource.Play();
    }
}
