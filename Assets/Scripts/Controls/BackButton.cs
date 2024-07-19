using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class BackButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            MovementManager.instance.backButtonPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.A)) 
        {
            MovementManager.instance.backButtonPressed = false;
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        MovementManager.instance.backButtonPressed = true;
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        MovementManager.instance.backButtonPressed = false;
    }
}
