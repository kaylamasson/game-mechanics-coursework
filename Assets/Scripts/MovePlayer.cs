using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MovePlayer : MonoBehaviour
{

    public string left;
    public string right; 


    public Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {

        rb = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 move = new Vector3(0,0,0);

        if (Input.GetKey(left))
        {
            move = new Vector3(-0.01f, 0, 0);
        }

        if (Input.GetKey(right))
        {
            move = new Vector3(0.01f, 0, 0);
        }

        this.transform.Translate(move);
        
    }
}
