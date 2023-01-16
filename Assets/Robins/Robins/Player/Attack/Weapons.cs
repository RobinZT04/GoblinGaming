using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public virtual void Attack() //Attack //Robin
    {
        print("Pew Pew");
    }

    public virtual void EndAttack() //EndAttack //Robin
    {
        print("!");
    }

    public virtual void RightClick() //Högerklick  //Robin
    {
        print("RightClick");
    }
}
