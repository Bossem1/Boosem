using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimationController : MonoBehaviour
{
    private int currentPoints = 1;
    private int nextPoint = 1;
    private int nextPoint1;
    private int nextPoint2;
    private int pointsToWin;

    void Start()
    {
        pointsToWin = 4;
        // if( PlayerPrefs.GetInt("KickButton") == 1 && PlayerPrefs.GetInt("HelloButton") == 2)
        // {
        //     Debug.Log("Thank God");
        // }
    }

    void Update()
    {
        if (currentPoints + nextPoint == pointsToWin)
        {
            Debug.Log("Thank God!");
        }
    }

    public void KickButtonTouch()
    {
        GetComponent<Animation>().Play("PlayMode_KickButton");
        currentPoints++;
        // PlayerPrefs.SetInt("KickButton", 1);
        // PlayerPrefs.Save();
    }

    public void HelloButtonTouch()
    {
        GetComponent<Animation>().Play("PlayMode_HelloButton");
        nextPoint++;
        // PlayerPrefs.SetInt("HelloButton", 2);
        // PlayerPrefs.Save();
    }
    public void JumpButtonTouch()
    {
        GetComponent<Animation>().Play("PlayMode_JumpButton");
        nextPoint1++;
    }
    public void DanceButtonTouch()
    {
        GetComponent<Animation>().Play("PlayMode_DanceButton");
        nextPoint2++;
    }
    public void RunButtonTouch()
    {
        GetComponent<Animation>().Play("PlayMode_RunButton");
    }
    public void WalkButtonTouch()
    {
        GetComponent<Animation>().Play("PlayMode_WalkButton");
    }
}
