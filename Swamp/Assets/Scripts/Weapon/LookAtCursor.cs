using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    void Update()
    {
        ChangeAngle();
    }

    private void ChangeAngle()
    {
        var mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        var angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);

        if (angle>=-30&&angle<=30)
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);
    }
}


