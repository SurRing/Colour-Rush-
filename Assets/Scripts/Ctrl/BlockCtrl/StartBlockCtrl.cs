using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBlockCtrl : BlockCtrl
{
    public List<Colour> rainbowList = new List<Colour>();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitialPlayerpPosition()
    {
        PlayerCtrl.Instance.transform.position = transform.position;
        PlayerCtrl.Instance.position = position;
        CameraCtrl.Instance.Set();
    }

    public override bool Check()
    {
        return true;
    }

    public override void Enter()
    {
        if (!rainbowList.Contains(PlayerCtrl.Instance.BodyColour))
        {
            Debug.Log("新颜色收集！");
            rainbowList.Add(PlayerCtrl.Instance.BodyColour);
            grow(PlayerCtrl.Instance.BodyColour);
            if(rainbowList.Count == MainMgr.Instance.difficulty)
            {
                MainMgr.Instance.victoryButton.SetActive(true);
                if (MainMgr.Instance.difficulty == 7)
                {
                    Debug.Log("这个游戏出乎意料的可以获胜诶！");
                    Debug.Log("你获胜了！开心吗！");
                }
            }
        }
    }

    public override void Exit(Colour enterBlock)
    {
        Debug.Log("Exit:离开白色！");
    }

    public void grow(Colour colour)
    {
        GameObject petal = ResourceMgr.Instance.Load(ResourceType.Accessory, "Petal");
        petal.transform.parent = transform;
        petal.transform.position = transform.position;
        petal.GetComponent<SpriteRenderer>().material.color = MainMgr.rainbow[colour];
        petal.transform.Rotate(0,0, 360 / MainMgr.Instance.difficulty * rainbowList.Count);
    }
}
