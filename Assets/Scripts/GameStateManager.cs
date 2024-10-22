using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Score: " + score);
    }


    public int getScore(){
        return score;
    }

    public void setScore(int score){
        this.score = score;
    }

    public void adjustScore(int s){
        score += s; 
        Debug.Log("Score: " + score); 
    }
}
