using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D body;
    public float speed;
    public bool bounceBack;

    public GameObject bullet;
    Transform bulletSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        bounceBack = false;
        body = GetComponent<Rigidbody2D>();
        Invoke("DestroyFunction", 0.85f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!bounceBack)
        {
            body.velocity = transform.up * 10;
        }
        /*if (bounceBack)
        {
            Transform bp = GameObject.FindGameObjectWithTag("BS").gameObject.transform;
            Instantiate(bullet, bp.position, bp.rotation);
            bounceBack = false;
            Destroy(gameObject);*/
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);

        if(collision.transform.tag == "Damage")
        {
            bounceBack = true;
        }
    }

    void DestroyFunction()
    {
        Destroy(gameObject);
    }
}
