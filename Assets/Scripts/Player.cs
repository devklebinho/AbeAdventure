using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LifeSystem
{
    public static Player instance { get; private set; }

    private void Awake()
    {
        if(instance != null )
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
