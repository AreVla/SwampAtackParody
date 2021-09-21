
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave 
{
    public List<GameObject> Templates;
    public float Delay;
    public int Count;
    [NonSerialized]
    public int Spawned;
}
