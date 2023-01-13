using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSoundScript : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioClip soundClip;

    [SerializeField]
    bool breakable;

    [SerializeField]
    bool loot;

    [SerializeField]
    GameObject trash;

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Damage")
        {
            if (!soundSource.isPlaying)
            {
                soundSource.PlayOneShot(soundClip, 1f);
            }
            if (breakable)
            {
                if (loot)
                    Instantiate(trash, transform.position, Quaternion.identity);
                    Destroy(gameObject);
            }
        }
    }
}
