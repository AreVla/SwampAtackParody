
using System;
using UnityEngine;

[Serializable]
public class Wave 
{
    public GameObject Template;
    public float Delay;
    public int Count;
    [NonSerialized]
    public int Spawned;
}
