using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    Animator anim;
    public static TreasureBox instance;
    // Start is called before the first frame update
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenBoxAnim()
    {
        anim.SetBool("Box", true);
    }
}
