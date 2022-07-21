using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimationController : MonoBehaviour
{
    void Start()
    {
        // if( PlayerPrefs.GetInt("KickButton") == 1 && PlayerPrefs.GetInt("HelloButton") == 2)
        // {
        //     Debug.Log("Thank God");
        // }
    }

    

    public void KickButtonTouch()
    {
        GetComponent<Animation>().Play("PlayMode_KickButton");
        // PlayerPrefs.SetInt("KickButton", 1);
        // PlayerPrefs.Save();
    }

    public void HelloButtonTouch()
    {
        GetComponent<Animation>().Play("PlayMode_HelloButton");
        // PlayerPrefs.SetInt("HelloButton", 2);
        // PlayerPrefs.Save();
    }
    public void JumpButtonTouch()
    {
        GetComponent<Animation>().Play("PlayMode_JumpButton");
    }
    public void DanceButtonTouch()
    {
        GetComponent<Animation>().Play("PlayMode_DanceButton");
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
