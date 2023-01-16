using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Transform box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sätter yxhitbox postionen //Robin
        box.transform.position = transform.position; 
        box.transform.eulerAngles = transform.eulerAngles;
    }
}
