using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMgr : MonoBehaviour {

    public static MapMgr Instance;

    public int radius = 5;

    public int rows;
    public int cols;

    public int floor_min = 1;
    public int floor_max = 8;

    //public Dictionary<string, BlockCtrl> blockDict = new Dictionary<string, BlockCtrl>();
    public BlockCtrl[,] blockArray;

    private void Awake()
    {
        Instance = this;
        rows = radius * 2 + 1;
        cols = radius * 2 + 1;
        blockArray = new BlockCtrl[rows, cols];
        //blockDict.Add("Floor1", new Floor1Ctrl());
        //blockDict.Add("Floor2", new Floor2Ctrl());
        //blockDict.Add("Floor3", new Floor3Ctrl());
        //blockDict.Add("Floor4", new Floor4Ctrl());
        //blockDict.Add("Floor5", new Floor5Ctrl());
        //blockDict.Add("Start", new StartBlockCtrl());
        //blockDict.Add("End", new EndBlockCtrl());
    }
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitialMap(int difficulty)
    {
        floor_max = difficulty + 1;
        for (int row = 0; row < rows; ++row)
        {
            for (int col = 0; col < cols; ++col)
            {
                string floorname = "Floor" + Random.Range(floor_min, floor_max).ToString();
                GameObject floor = ResourceMgr.Instance.Load(ResourceType.Block, floorname);
                floor.transform.parent = transform;
                floor.transform.position = new Vector2(row - (rows/2-0.5f), col - (cols / 2 - 0.5f)) * MainMgr.BlockLength;
                blockArray[row, col] = floor.GetComponent<BlockCtrl>();
                floor.GetComponent<BlockCtrl>().position = new Position(row, col);
            }
        }

        //GameObject EndBlock = ResourceMgr.Instance.Load(ResourceType.Block, "End");
        //EndBlock.transform.parent = transform;
        //EndBlock.transform.position = new Vector2(rows-1 - (rows / 2 - 0.5f), cols-1 - (cols / 2 - 0.5f)) * MainMgr.BlockLength;
        //blockArray[rows-1, cols-1] = EndBlock.GetComponent<BlockCtrl>();
        //EndBlock.GetComponent<BlockCtrl>().position = new Position(rows-1, cols-1);

        Destroy(blockArray[radius, radius].gameObject);

        GameObject StartBlock = ResourceMgr.Instance.Load(ResourceType.Block, "Start");
        StartBlock.transform.parent = transform;
        StartBlock.transform.position = new Vector2(radius - (rows / 2 - 0.5f), radius - (cols / 2 - 0.5f)) * MainMgr.BlockLength;
        blockArray[radius, radius] = StartBlock.GetComponent<StartBlockCtrl>();
        StartBlock.GetComponent<StartBlockCtrl>().position = new Position(radius, radius);

        StartBlock.GetComponent<StartBlockCtrl>().InitialPlayerpPosition();
    }

    public void Reroll(Position position)
    {
        string floorname = "Floor" + Random.Range(floor_min, floor_max).ToString();
        GameObject floor = ResourceMgr.Instance.Load(ResourceType.Block, floorname);
        floor.transform.parent = transform;
        floor.transform.position = new Vector2(position.x - (rows / 2 - 0.5f), position.y - (cols / 2 - 0.5f)) * MainMgr.BlockLength;
        blockArray[position.x, position.y] = floor.GetComponent<BlockCtrl>();
        Debug.Log(position + "is" + floorname + "now");
    }

    public void Change(Position position, int floorid)
    {
        Destroy(blockArray[position.x, position.y].gameObject);
        string floorname = "Floor" + floorid.ToString();
        Debug.Log(floorname);
        GameObject floor = ResourceMgr.Instance.Load(ResourceType.Block, floorname);
        floor.transform.parent = transform;
        floor.transform.position = new Vector2(position.x - (rows / 2 - 0.5f), position.y - (cols / 2 - 0.5f)) * MainMgr.BlockLength;
        blockArray[position.x, position.y] = floor.GetComponent<BlockCtrl>();
        floor.GetComponent<BlockCtrl>().position = new Position(position.x, position.y);
        Debug.Log(position + "is" + floorname + "now");
    }

    public void Reset()
    {
        for (int row = 0; row < rows; ++row)
        {
            for (int col = 0; col < cols; ++col)
            {
                Destroy(blockArray[row, col].gameObject);
            }
        }
    }

}
