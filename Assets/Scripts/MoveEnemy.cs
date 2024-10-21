using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveEnemy : MonoBehaviour
{


    public float startPoint;
    public float endPoint;
    private float xPos;
    private bool isFacingRight = false;  
    private Animator animator; 
    private bool reachedEdge; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    xPos = this.transform.position.x;

    if ((endPoint < xPos) && (isFacingRight == false))
    {
        animator.SetBool("isWalking",true);
        this.transform.Translate(-0.005f,0,0);
        reachedEdge = false;

    }



    if((Math.Round(endPoint,3) == Math.Round(xPos,3)) && (reachedEdge == false))
    {
        reachedEdge = true;
        FlipSprite();
        isFacingRight = true;
    }

    

    

    if ((startPoint > xPos) && (isFacingRight == true))
    {
        animator.SetBool("isWalking",true);
        this.transform.Translate(0.005f,0,0);
        reachedEdge = false;

    }

    
    
    if ((Math.Round(startPoint,2) == Math.Round(xPos,2)) && (reachedEdge == false))
    {
        reachedEdge = true;
        //sprite flipping 3x ?
        FlipSprite();
        isFacingRight = false;
    }
    
    }

    void FlipSprite()
    {
        Debug.Log("Sprite flipped");
        Vector3 ls = this.transform.localScale;
        ls.x *= -1;
        this.transform.localScale = ls;
    }
}
