using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonSelector : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    public ScrollRectScript scrollRectScript;
    [SerializeField]
    public bool isDownButton;
    public void  OnPointerDown (PointerEventData eventData)
    {
        if(isDownButton)
        {
            scrollRectScript.ButtonDownIsPressed();
        }
        else
        {
            scrollRectScript.ButtonUpIsPressed();
        }
    }
}
