using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictorButtonCtrl : MonoBehaviour {

    private int count = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickMore()
    {
        count += 1;
        if(count == 1)
        {
            Debug.Log("点这个没什么用的。");
        }
        else if(count < 100)
        {
            Debug.Log("你已经点了" + count.ToString() + "下了。真的没什么用的。");
        }
        else if(count == 100)
        {
            transform.Find("Text").GetComponent<Text>().text = "You Really Win!";
            Debug.Log("我承认你赢了啦！！！不要戳我了啦！！！！！");
        }
    }
}
