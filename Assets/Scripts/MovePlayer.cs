using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MovePlayer : MonoBehaviour
{

    public string left;
    public string right; 
    public string jump; 

    private bool isFacingRight = true; 

    private float horizontalInput; 


    public Animator animator; 
    public bool isJumping = false; 


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

        if (horizontalInput != 0)
        {
            animator.SetBool("isWalking",true);
        } else 
        {
            animator.SetBool("isWalking",false);
        }

        if (Input.GetKey(left))
        {
            move = new Vector3(-0.02f, 0, 0);
        }

        if (Input.GetKey(right))
        {
            move = new Vector3(0.02f, 0, 0);
        }

        if (Input.GetKey(jump) && isJumping == false)
        {

            animator.SetBool("isWalking",false);
            isJumping = true;
            rb.AddForce(this.transform.up * 1500);
        }

        this.transform.Translate(move);
        
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
    }
}
