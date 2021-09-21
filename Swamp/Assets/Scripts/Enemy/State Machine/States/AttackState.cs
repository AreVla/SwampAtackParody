using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private float damage;
    [SerializeField] private float _delay;

    private float _lastAtackTime;

    private void Start()
    {
        TryGetComponent(out Animator animator);
        animator.Play("Attack");
    }

    private void Update()
    {
        if(_lastAtackTime<=0)
        {
            Attack(Target);
            _lastAtackTime = _delay;
        }
        _lastAtackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        target.TakeDamage(damage);
    }
}
