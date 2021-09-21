using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTransition : Transition
{
    private void Update()
    {
        if(gameObject.TryGetComponent(out Enemy enemy))
            if (enemy.Health <= 0)
                NeedTransit = true;
    }
}
