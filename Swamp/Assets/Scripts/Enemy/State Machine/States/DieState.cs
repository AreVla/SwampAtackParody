using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    private float _timeForAnimation;
    private float _currentTime=0;

    private void Start()
    {
        TryGetComponent(out Animator animator);
        animator.Play("Death");
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        _timeForAnimation = info.length;
    }

    private void Update()
    {
        Die();
    }

    private void Die()
    {
        _currentTime += Time.deltaTime;

        if (_timeForAnimation <= _currentTime) 
            Destroy(gameObject);
    }
}
