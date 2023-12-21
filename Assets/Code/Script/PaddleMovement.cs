using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private float _paddleYPosition = -4f;
    private float _paddleZPosition = -.25f;

    private void Update()
    {
        MoveToMouseX();
    }

    private void MoveToMouseX()
    {
        float mousePositionX = GetWorldMousePosition().x;
        Vector3 newPosition = new Vector3(mousePositionX, _paddleYPosition, _paddleZPosition);

        transform.position = newPosition;
    }

    private Vector3 GetWorldMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;

        float screenDepth = 10;
        Vector3 mouseScreenPoint = new Vector3(mousePosition.x, mousePosition.y, screenDepth);

        return Camera.main.ScreenToWorldPoint(mouseScreenPoint);
    }
}
