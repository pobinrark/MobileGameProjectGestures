using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    string move;
    public string TRIANGLE = "Triangle";
    public string SQUARE = "Square";
    public string H_LINE = "horizontal";
    private int health = 100;
    
    private PlayerGestureHandler gestureHandler;
	// Use this for initialization
	void Start () {
        gestureHandler = gameObject.GetComponent<PlayerGestureHandler>();
        Debug.Log("Player Controller result " + gestureHandler.textResult.text);
        Debug.Log("Player Controller reference " + gestureHandler.referenceRoot.ToString());
        GameObject drawArea = GameObject.FindGameObjectWithTag("drawArea");
        drawArea.GetComponent<GestureRecognizer.DrawDetector>().maxLines = 1;
	}
	
	// Update is called once per frame
	void Update () {
        string gestureId = gestureHandler.recognitionResult;
        if (gestureId != "")
        {
            gestureHandler.textResult.text = gestureId + " " + health;
        }

	}

    public string getMove()
    {
        return gestureHandler.recognitionResult;
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }

    public int getHealth()
    {
        return health;
    }
}
