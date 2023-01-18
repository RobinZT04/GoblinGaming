using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLight : MonoBehaviour
{
    public AudioSource audioSource;

    //N�r spelarkarakt�ren nuddar objektet f�rst�rs det och en ljudeffekt spelas -William
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.Play();
            Invoke("destroyObj", 0.3f);

        }
    }

    void destroyObj()
    {
        Destroy(gameObject);
    }
}
