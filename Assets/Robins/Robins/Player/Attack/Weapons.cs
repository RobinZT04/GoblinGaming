using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public virtual void Attack()
    {
        print("Pew Pew");
    }

    public virtual void EndAttack()
    {
        print("!");
    }
}
