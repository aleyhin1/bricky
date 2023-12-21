using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private float _paddleYPosition = -5f;
    private float _paddleZPosition = -.25f;
    private float _xAxisBorder;

    private void Start()
    {
        _xAxisBorder = GetXAxisBorder();
    }

    private void Update()
    {
        MoveToMouseX();
    }

    private void MoveToMouseX()
    {
        float mousePositionX = GetWorldMousePosition().x;
        mousePositionX = Mathf.Clamp(mousePositionX, -_xAxisBorder, _xAxisBorder);
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

    private float GetXAxisBorder()
    {
        float screenDepth = 10f;
        Vector3 viewportVector = new Vector3(1, 0, screenDepth);
        return Camera.main.ViewportToWorldPoint(viewportVector).x;
    }
}
