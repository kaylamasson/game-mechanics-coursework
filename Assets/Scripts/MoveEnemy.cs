using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveEnemy : MonoBehaviour
{


    public float startPoint;
    public float endPoint;
    private float xPos;
    public bool isFacingRight = false;  
    private Animator animator; 
    private bool reachedEdge; 
    private float animTime;
    private bool isHit; 
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
        this.transform.Translate(-0.003f,0,0);
        reachedEdge = false; 
    }

    if((Math.Round(endPoint,3) >= Math.Round(xPos,3)) && (reachedEdge == false))
    { 
        reachedEdge = true;
        FlipSprite();
        isFacingRight = true;
    }

    

    

    if ((startPoint > xPos) && (isFacingRight == true))
    {
        animator.SetBool("isWalking",true);
        this.transform.Translate(0.003f,0,0);
        reachedEdge = false;

    }

    
    
    if ((Math.Round(startPoint,2) <= Math.Round(xPos,2)) && (reachedEdge == false))
    {
        reachedEdge = true;
        //sprite flipping 3x ?
        FlipSprite();
        isFacingRight = false;

    }

    if (isHit)
    {
        animTime ++;
        if (animTime > 2) 
        {
            animator.SetBool("isHit",false);
            isHit = false;
        }
    }
    
    

    }

    void FlipSprite()
    {
        Vector3 ls = this.transform.localScale;
        ls.x *= -1;
        this.transform.localScale = ls;
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            isHit = true;
            animator.SetBool("isHit",true);
        }
    }
   
    
}
