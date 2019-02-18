using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowPlaneCtrl : MonoBehaviour {
    public List<GameObject> rainbowImage;

    private void Awake()
    {
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitialRainbow(int difficulty)
    {
        for(int i = 0; i < difficulty; ++i)
        {
            rainbowImage[i].SetActive(true);
        }
        GetComponent<RectTransform>().offsetMax = new Vector2((difficulty * 20 + 20)-Screen.width, 0);
        GetComponent<RectTransform>().offsetMin = new Vector2(0, Screen.height-40);
        gameObject.SetActive(true);
    }

    public void Reset()
    {
        for (int i = 0; i < MainMgr.Instance.difficulty; ++i)
        {
            rainbowImage[i].SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
