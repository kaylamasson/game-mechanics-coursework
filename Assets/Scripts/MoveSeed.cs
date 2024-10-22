using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSeed : MonoBehaviour
{

    public float seedSpeed; 
    private MovePlayer player;
    private int direction; 
    private int timeFired; 
    public GameStateManager gsm; 
    // Start is called before the first frame update
    void Start()
    {
        gsm = GameObject.Find("GameState").GetComponent<GameStateManager>(); 
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
        Destroy(this.gameObject, 2);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gsm.adjustScore(100); 
            Destroy(this.gameObject);
        }
    }
}
