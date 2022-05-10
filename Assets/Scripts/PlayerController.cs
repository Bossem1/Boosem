using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public void Update()
    {
        Left();
        Right();
        Up();
        Down();

    }
    
    public void Left()
    {
        transform.Translate(-1,0,0);
            
    }
    public void Right()
    {
        transform.Translate(1,0,0);
            
    }
    public void Up()
    {
        transform.Translate(0,1,0);
      
    }
    public void Down()
    {
        transform.Translate(0,-1,0);
            
    }
}
