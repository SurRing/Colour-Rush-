using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCtrl : MonoBehaviour {

    public int id;
    public Colour Body;
    public Colour Left;
    public Colour Right;
    public Position position;

    public void Awake()
    {
        Body = (Colour)id;
        if (id == 1)
        {
            Left = (Colour)MainMgr.Instance.difficulty;
            Right = Body + 1;
        }
        else if (id == MainMgr.Instance.difficulty)
        {
            Left = Body - 1;
            Right = (Colour)1;
        }
        else
        {
            Left = Body - 1;
            Right = Body + 1;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual bool Check()
    {
        if (PlayerCtrl.Instance.BodyColour == Colour.White)
        {
            Debug.Log("Check:白色准入！");
            return true;
        }
        if (PlayerCtrl.Instance.BodyColour == Body)
        {
            Debug.Log("Check:同色准入！");
            return true;
        }
        if (PlayerCtrl.Instance.LeftColour == Body)
        {
            Debug.Log("Check:左手准入！");
            return true;
        }
        if (PlayerCtrl.Instance.RightColour == Body)
        {
            Debug.Log("Check:右手准入！");
            return true;
        }
        Debug.Log("Check:禁入！");
        return false;
    }
    public virtual void Enter() {
        if (PlayerCtrl.Instance.BodyColour == Body)
        {
            Debug.Log("Enter:同色进入！");
            return;
        }
        Debug.Log("Enter:变色进入！");
        PlayerCtrl.Instance.Colour(Left, Body, Right);
    }

    public virtual void Exit(Colour enterBlock) {
        if (enterBlock == Colour.White)
        {
            Debug.Log("Exit:进入白色！");
            return;
        }
        if (Right == enterBlock)
        {
            Debug.Log("Exit:进入右手！");
            int num = id - 1;
            if(num == 0)
            {
                num = MainMgr.Instance.difficulty;
            }
            MapMgr.Instance.Change(position, num);
        }
        else if (Left == enterBlock)
        {
            Debug.Log("Exit:进入左手！");
            int num = id + 1;
            if (num == MainMgr.Instance.difficulty+1)
            {
                num = 1;
            }
            MapMgr.Instance.Change(position, num);
        }
        Debug.Log("Exit:进入同色！");
    }
}
