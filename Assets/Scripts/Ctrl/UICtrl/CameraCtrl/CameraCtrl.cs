using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public static CameraCtrl Instance;
    public Transform player;//获得角色

    private void Awake()
    {
        Instance = this;
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    void Start()
    {
    }

    void Update()
    {
    }

    public void Set()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    public void Follow(int x, int y)
    {
        transform.position += new Vector3(x, y, 0) * MainMgr.BlockLength;
    }
}
