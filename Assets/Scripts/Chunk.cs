using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对象池
/// </summary>
public class Chunk
{
    /// <summary>
    /// 池子容器
    /// </summary>
    private List<Object> objectList;

    public bool IsHave => objectList.Count > 0;

    public Chunk()
    {
        objectList = new List<Object>();
    }

    public Object GetObj()
    {
        //取第一个
        Object obj = objectList[objectList.Count - 1];
        //从池子移除
        objectList.RemoveAt(objectList.Count - 1);
        return obj;
    }

    public void ReverObj(Object obj)
    {
        (obj as GameObject).transform.parent = null;
        (obj as GameObject).gameObject.SetActive(false);
        objectList.Add(obj);
    }
    
}
