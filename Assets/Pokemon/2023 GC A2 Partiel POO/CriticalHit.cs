using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class CriticalHit
{
    public CriticalHit(System.Random random, int power)
    {
        random.Next(1,5);
        power *= 1.25f;
    }

    public System.Random random { get; private set; }
}
