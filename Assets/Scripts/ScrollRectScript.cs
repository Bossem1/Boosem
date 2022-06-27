using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ScrollRectScript : MonoBehaviour
{
    private ScrollRect scrollRect;
    private bool mouseDown, buttonDown, buttonUp;
    public static ScrollRectScript instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseDown){
            if(buttonDown)
            {
                ScrollDown();
            }
            else if(buttonUp)
            {
                ScrollUp();
            }
        }
    }
    public void ButtonDownIsPressed()
    {
        mouseDown = true;
        buttonDown = true;
    }
    public void ButtonUpIsPressed()
    {
        mouseDown= true;
        buttonUp = true;
    }
    private void ScrollDown()
    {
        if(Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            buttonDown = false;
        }
        else
        {
            scrollRect.verticalNormalizedPosition -= 0.01f;
        }
    }
    private void ScrollUp()
    {
        if(Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            buttonDown = false;

        }
        else
        {
            scrollRect.verticalNormalizedPosition += 0.01f;
        }
    }
}
