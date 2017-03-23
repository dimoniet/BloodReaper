﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeLogic : MonoBehaviour {

    ScoreSystem score;

    public RecieveAttack recieveAttack;

    // Use this for initialization
	void Start () 
    {
        score = GameObject.FindGameObjectWithTag("Manager").GetComponent<ScoreSystem>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (recieveAttack.DamageRecived == true)
        {
            //Start Break Animation/pysics

            //White a time

            //Dissolve

            //Destroy barricade
            score.AddScoreBarricade();
            Destroy(gameObject);
        }
	}
}