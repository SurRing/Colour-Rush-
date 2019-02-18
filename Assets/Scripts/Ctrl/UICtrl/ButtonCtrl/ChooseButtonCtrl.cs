using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseButtonCtrl : MonoBehaviour {

    public int num;
    public GameObject ChosePlane;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click()
    {
        MainMgr.Instance.DifficultySet(num);
        ChosePlane.SetActive(false);
    }
}
