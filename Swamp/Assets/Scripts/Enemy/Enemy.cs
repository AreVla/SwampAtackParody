using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private int _reward;
    [SerializeField] private Animator _animator;

    private Player _target;

    public UnityAction<Enemy> Dying;

    public Player Target => _target;
    public int Reward => _reward;
    public Animator Animator => _animator;
    public float Health => _health;

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
            Dying?.Invoke(this);
    }
}
