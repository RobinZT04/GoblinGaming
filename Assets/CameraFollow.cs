using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 point = Camera.main.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.35f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

        /*[SerializeField]
         Transform player;
         [SerializeReference]
         float movementSpeed;

         // Update is called once per frame
         void Update()
         {
             //transform.position += (player.transform.position - transform.position).normalized * movementSpeed * Time.deltaTime;
             transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
         }
         */
    }
}
