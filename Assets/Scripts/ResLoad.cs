using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResLoad : SingleMono<ResLoad>
{
    public GameObject LoadPrefab(string resName)
    {
        GameObject go = Resources.Load<GameObject>(resName);
        if (go == null)
        {
            Debug.Log(resName);
            Debug.LogError(message: "ResLoad:Resources加载路径加载失败");
            return null;
        }

        return Instantiate(go);
    }

    public GameObject LoadPrefab(GameObject go)
    {
        if (go == null)
        {
            Debug.LogError(message: "ResLoad:GameObject加载失败");
            return null;
        }
        return GameObject.Instantiate(go);
    }
    
    public T LoadAsset<T>(string pathName,string resName)
        where T: Object
    {
        return Resources.Load<T>(path:pathName + "/" + resName);
    }

    public T LoadAsset<T>(string resName)
        where T : Object
    {
        return Resources.Load<T>(resName);
    }
}
