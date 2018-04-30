using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public Text gameResult;
    public GameObject player;
    public GameObject computer;
    string playerMove;
    string cpuMove;
    private PlayerController pc;
    private PlayerController cc;

    [System.Serializable]
    public class RoundFinished : UnityEvent { };
    public RoundFinished onRoundFinished;

    // Use this for initialization
    void Start () {
        pc = player.GetComponent<PlayerController>();
        cc = computer.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void RoundStart()
    {

    }

    private void checkWinner(int a, int b)
    {
        if(a > 0 && b > 0)
        {
            return;
        }
        if (a <= 0 && b > 0)
        {
            Debug.Log("CPU Won");
            gameResult.text = "YOU LOSE U FUCKING LOSER";
            
        }
        else if (a > 0 && b <= 0)
        {
            Debug.Log("Player Won");
            gameResult.text = "YOU WIN";
        }
    }

    public void SetPlayerMoves()
    {
        playerMove = pc.getMove();
        Debug.Log("GameManager.RoundEnd Player Move: " + playerMove);
        int randNum = Random.Range(0, 3);
        if(randNum == 0)
        {
            cpuMove = pc.SQUARE;
        }
        else if(randNum == 1)
        {
            cpuMove = pc.TRIANGLE;
        }
        else if(randNum == 2)
        {
            cpuMove = pc.H_LINE;
        }
        //CPU Code might need to get rid of
        Debug.Log("Computer's Move: " + cpuMove);
        
        onRoundFinished.Invoke();
    }

    public void CalculateDamage()
    {
        if(playerMove != null && cpuMove != null)
        {   
            if(playerMove == pc.TRIANGLE)
            {
                if (cpuMove == pc.SQUARE)
                {
                    Debug.Log("Computer takes damage");
                    cc.takeDamage(50);
                }
                else if (cpuMove == pc.H_LINE)
                {
                    Debug.Log("Player takes damage");
                    pc.takeDamage(50);
                }
                else
                {
                    Debug.Log("Attacks nullified");
                }
            }
            else if (playerMove == pc.SQUARE)
            {
                if (cpuMove == pc.H_LINE)
                {
                    Debug.Log("Computer takes damage");
                    cc.takeDamage(50);
                }
                else if (cpuMove == pc.TRIANGLE)
                {
                    Debug.Log("Player takes damage");
                    pc.takeDamage(50);
                }
                else
                {
                    Debug.Log("Attacks nullified");
                }
            }
            else if (playerMove == pc.H_LINE)
            {
                if (cpuMove == pc.TRIANGLE)
                {
                    Debug.Log("Computer takes damage");
                    cc.takeDamage(50);
                }
                else if (cpuMove == pc.SQUARE)
                {
                    Debug.Log("Player takes damage");
                    pc.takeDamage(50);
                }
            }
        }
        else
        {
            Debug.Log("One of the players has not made a move");
            return;
        }
        //computer code might need to get rid of
        computer.GetComponent<PlayerGestureHandler>().textResult.text = cpuMove + " " + cc.getHealth();
        Debug.Log("Player Health: " + pc.getHealth());
        Debug.Log("Computer Health: " + cc.getHealth());
        checkWinner(pc.getHealth(), cc.getHealth());

    }

    public void reloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    

}
