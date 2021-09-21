using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private void Start()
    {
        TryGetComponent(out Animator animator);
        animator.Play("Idle");
    }
}
