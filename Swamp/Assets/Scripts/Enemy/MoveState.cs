using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var newPosition = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        transform.position = newPosition;
    }
}
