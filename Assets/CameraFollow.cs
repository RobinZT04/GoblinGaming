using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeReference]
    float movementSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += (player.transform.position - transform.position).normalized * movementSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
