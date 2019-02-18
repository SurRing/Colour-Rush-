using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    public SpriteRenderer LeftSprite;
    public SpriteRenderer BodySprite;
    public SpriteRenderer RightSprite;

    public Colour LeftColour;
    public Colour BodyColour;
    public Colour RightColour;

    public static PlayerCtrl Instance;

    public Position position;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        position = new Position(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Move(int x, int y)
    {
        if (!MapMgr.Instance.blockArray[position.x + x, position.y + y].Check()) return;//检查目标方块是否可以进入
        MapMgr.Instance.blockArray[position.x, position.y].Exit(MapMgr.Instance.blockArray[position.x+x, position.y+y].Body);//退出当前方块
        position.x += x;
        position.y += y;
        transform.position += new Vector3(x,y,0) * MainMgr.BlockLength;
        CameraCtrl.Instance.Follow(x, y);
        MapMgr.Instance.blockArray[position.x, position.y].Enter();//进入目标方块

    }

    public void Colour(Colour Left, Colour Body, Colour Right)
    {
        LeftColour = Left;
        BodyColour = Body;
        RightColour = Right;

        LeftSprite.material.color = MainMgr.rainbow[LeftColour];
        BodySprite.material.color = MainMgr.rainbow[BodyColour];
        RightSprite.material.color = MainMgr.rainbow[RightColour];

        Debug.Log("颜色发生变化！");
    }
}
