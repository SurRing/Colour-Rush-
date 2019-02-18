using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Colour
{
    White,
    Red,
    Orange,
    Yellow,
    Green,
    Cyan,
    Blue,
    Purple,
    Black,
}

public class MainMgr : MonoBehaviour {

    public static MainMgr Instance;
    public static float BlockLength;
    public static Dictionary<Colour, Color> rainbow = new Dictionary<Colour, Color>();

    public StartBlockCtrl StartBlock;

    public PlayerCtrl player;
    public MapMgr map;
    public int difficulty;

    public GameObject chossePlane;
    public RainbowPlaneCtrl rainbowPlane;
    public GameObject victoryButton;

    private void Awake()
    {
        Instance = this;
        BlockLength = player.GetComponent<SpriteRenderer>().bounds.size.x;
        rainbow.Add(Colour.White, new Color(0, 0, 0));
        rainbow.Add(Colour.Red, new Color(255 / 255f, 0, 0));
        rainbow.Add(Colour.Orange, new Color(255 / 255f, 152 / 255f, 0));
        rainbow.Add(Colour.Yellow, new Color(255 / 255f, 255 / 255f, 0));
        rainbow.Add(Colour.Green, new Color(0, 255 / 255f, 0));
        rainbow.Add(Colour.Cyan, new Color(0, 255 / 255f, 255 / 255f));
        rainbow.Add(Colour.Blue, new Color(0, 0, 255 / 255f));
        rainbow.Add(Colour.Purple, new Color(150 / 255f, 0, 255 / 255f));
        rainbow.Add(Colour.Black, new Color(255 / 255f, 255 / 255f, 255 / 255f));
    }

    // Use this for initialization
    void Start () {
        chossePlane.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.W))
        {
            if(player.position.y< map.rows-1) player.Move(0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (player.position.x > 0) player.Move(-1, 0);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            if (player.position.y > 0) player.Move(0, -1);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            if (player.position.x < map.cols - 1) player.Move(1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            
        }
    }

    public void DifficultySet(int num)
    {
        difficulty = num;
        GameSet();
    }

    public void GameSet()
    {
        map.InitialMap(difficulty);
        rainbowPlane.InitialRainbow(difficulty);
    }

    public void Reset()
    {
        rainbowPlane.Reset();
        MapMgr.Instance.Reset();
        victoryButton.SetActive(false);


        chossePlane.SetActive(true);
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
