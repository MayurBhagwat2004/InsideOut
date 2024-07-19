using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForwardButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            MovementManager.instance.forwardButtonPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            MovementManager.instance.forwardButtonPressed = false;
        }
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        MovementManager.instance.forwardButtonPressed = true;
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        MovementManager.instance.forwardButtonPressed = false;
    }
}
