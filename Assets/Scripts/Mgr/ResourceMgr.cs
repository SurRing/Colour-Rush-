using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public enum ResourceType
{
    Block,
    Floor,
    Barrier,
    Accessory,
    Role,
    UIScene,
    UIWindow,
    Item,
    NPC,
    None
}

public class ResourceMgr : Singleton<ResourceMgr>
{
    public GameObject Load(ResourceType type, string path)
    {
        StringBuilder stringBuilder = new StringBuilder();
        switch (type)
        {
            case ResourceType.Block:
                stringBuilder.Append("Blocks/");
                break;
            case ResourceType.Floor:
                stringBuilder.Append("Blocks/Floors/");
                break;
            case ResourceType.Barrier:
                stringBuilder.Append("Blocks/Barriers/");
                break;
            case ResourceType.Role:
                stringBuilder.Append("Roles/");
                break;
            case ResourceType.Accessory:
                stringBuilder.Append("Accessories/");
                break;
            case ResourceType.UIScene:
                stringBuilder.Append("UI/Scenes/");
                break;
            case ResourceType.UIWindow:
                stringBuilder.Append("UI/Windows/");
                break;
            case ResourceType.Item:
                stringBuilder.Append("Items/");
                break;
            case ResourceType.NPC:
                stringBuilder.Append("NPC/");
                break;
            case ResourceType.None:
                stringBuilder.Append("");
                break;
        }

        stringBuilder.Append(path);
        //Debug.Log(stringBuilder.ToString());
        GameObject obj = null;
        obj = Resources.Load(stringBuilder.ToString()) as GameObject;
        if (obj != null) return GameObject.Instantiate(obj);
        else return null;
    }
}
