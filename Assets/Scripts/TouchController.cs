using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector2 clampedPosition;
    private Vector2 startPosition;
    private bool onTouch = false;
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = eventData.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        clampedPosition = ClampValuesToMagnitude(eventData.delta);
        if(onTouch )
        {
            onTouch = false;
            if (Mathf.Abs(clampedPosition.x) > Mathf.Abs(clampedPosition.y))
            {
                if (clampedPosition.x > 0)
                {
                    GameController.input?.Invoke(GameController.Direction.Right);
                }
                else
                {
                    GameController.input?.Invoke(GameController.Direction.Left);
                }
            }
            else
            {
                if (clampedPosition.y > 0)
                {
                    GameController.input?.Invoke(GameController.Direction.Top);
                }
                else
                {
                    GameController.input?.Invoke(GameController.Direction.Down);
                }
            }
        }
    }

    private Vector2 ClampValuesToMagnitude(Vector2 position)
    {

        return Vector2.ClampMagnitude(position, 1);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        onTouch = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}