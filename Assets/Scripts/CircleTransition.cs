using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CircleTransition : MonoBehaviour
{
   private Canvas _canvas;
   private Image _blankScreen;
   private static readonly int RADIUS = Shader.PropertyToID("_Radius");

   private void Awake()
   {
       _canvas = GetComponent<Canvas>();
       _blankScreen = GetComponentInChildren<Image>();
   }

   private void Start()
   {
       DrawBlankScreen();
   }

   private void Update()
   {
       if(Input.GetKeyDown(KeyCode.Alpha1))
       {
           OpenBlankScreen();
       }
       else if(Input.GetKeyDown(KeyCode.Alpha2))
       {
           CloseBlankScreen();
       }
   }

   public void OpenBlankScreen()
   {
       StartCoroutine(Transition(2, 0, 1));
   }

   public void CloseBlankScreen()
   {
       StartCoroutine(Transition(2, 1, 0));
   }

   private void DrawBlankScreen()
   {
       var canvasRect = _canvas.GetComponent<RectTransform>().rect;
       var canvasWidth = canvasRect.width;
       var canvasHeight = canvasRect.height * 2;

       var squareValue = 0f;
       if(canvasWidth > canvasHeight)
       {
           squareValue = canvasWidth;
       }
       else
       {
           squareValue = canvasHeight;
       }

       _blankScreen.rectTransform.sizeDelta = new Vector2(squareValue, canvasHeight);

   }

   private IEnumerator Transition(float duration, float beginRadius, float endRadius)
   {
       var time = 0f;
       while (time <= duration)
       {
           time += Time.deltaTime;
           var t = time / duration;
           var radius = Mathf.Lerp(beginRadius, endRadius, t);

           _blankScreen.material.SetFloat(RADIUS, radius);

           yield return null;

       }
   }
}
