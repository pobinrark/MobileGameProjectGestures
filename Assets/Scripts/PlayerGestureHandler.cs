using System.Collections;
using System.Collections.Generic;
using GestureRecognizer;
using UnityEngine;

public class PlayerGestureHandler : GestureHandler {

    public string recognitionResult;

    public void Start()
    {
        Debug.Log(textResult);
        Debug.Log(referenceRoot);
    }

    public override void OnRecognize(RecognitionResult result)
    {
        string msg; StopAllCoroutines();
        StopAllCoroutines();
        if (result != RecognitionResult.Empty)
        {
            recognitionResult = result.gesture.id;
            Debug.Log("Player gesture handler on recognize " + recognitionResult);
        }
        
    }
}
