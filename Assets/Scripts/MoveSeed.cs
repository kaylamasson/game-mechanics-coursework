using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSeed : MonoBehaviour
{

    public float seedSpeed; 
    private MovePlayer player;
    private int direction; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").GetComponent<MovePlayer>();
        if (player.isFacingRight)
        {
            direction = 1;
        } else
        {
            direction = -1; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(seedSpeed * direction,0,0); 
    }
}
