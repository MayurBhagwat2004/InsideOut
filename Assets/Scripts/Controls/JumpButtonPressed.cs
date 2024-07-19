using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButtonPressed : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MovementManager.instance.jumpButtonPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            MovementManager.instance.jumpButtonPressed = false;
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        MovementManager.instance.jumpButtonPressed = true;
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        MovementManager.instance.jumpButtonPressed = false;
    }
    
}
