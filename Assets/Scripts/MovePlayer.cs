using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MovePlayer : MonoBehaviour
{

    public string left;
    public string right; 
    public string down; 
    public string up;
    public string jump; 
    public GameObject seedPrefab; 
    public string throwSeed; 
    private float lastThrown; 

    public float speed;

    public bool isFacingRight = true; 

    private float horizontalInput; 

    public Animator animator; 
    public bool isJumping = false; 

    public bool isCrouching; 


    public Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {

        rb = this.GetComponent<Rigidbody2D>();
        horizontalInput = Input.GetAxis("Horizontal");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        //Debug.Log(horizontalInput);

        Vector3 move = new Vector3(0,0,0);

        //if character is moving
        // play walk animation
        if (horizontalInput != 0)
        {
            animator.SetBool("isWalking",true);
        }  else 
        {
            animator.SetBool("isWalking",false);
        }


        // move character based on keyboard input
        if (Input.GetKey(left))
        {
            move = new Vector3(-speed, 0, 0);
            animator.SetBool("isCrouching",false); 

        }

        if (Input.GetKey(right))
        {
            move = new Vector3(speed, 0, 0);
            animator.SetBool("isCrouching",false); 
        }

        if (Input.GetKey(up))
        {
            animator.SetBool("isCrouching",false); 
        }

        if (Input.GetKey(down))
        {
            isCrouching = true; 
            animator.SetBool("isCrouching",true); 
        }


        //jump is space key pressed and character is on ground
        if (Input.GetKey(jump) && isJumping == false)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isWalking",false);
            isJumping = true;
            rb.AddForce(this.transform.up * 2000);
        }

        GameObject tmpSeed; 

        if (Input.GetKey(throwSeed))
        {
            if (Time.time > lastThrown + 1)
            {
                tmpSeed = Instantiate(seedPrefab, transform.position, transform.rotation); 
                lastThrown = Time.time;
            }

        }

        //move character
        this.transform.Translate(move);
        
        //make character face direction of movement
        FlipSprite();
    }


    void FlipSprite()
    {

        if ((isFacingRight && horizontalInput < 0f) || (!isFacingRight && horizontalInput > 0f))
        {

            isFacingRight = !isFacingRight;
            Vector3 ls = this.transform.localScale;
            ls.x *= -1;
            this.transform.localScale = ls;

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
        animator.SetBool("isCrouching",false);
        animator.SetBool("isWalking",false);
        animator.SetBool("isJumping", false);
    }
}