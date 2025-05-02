using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Manager : MonoBehaviour
{
    public float score;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            if(playerControllerScript.dash)
            {
                score += 2;
            }
            else
            {
                score++;
            }
            Debug.Log("Score; "+score);
        }
    }
}
