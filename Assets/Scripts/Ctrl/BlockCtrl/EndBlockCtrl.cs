using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBlockCtr : BlockCtrl
{

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("!");
        }
	}

    public override void Enter()
    {
        Debug.Log("Teah");
    }
}
