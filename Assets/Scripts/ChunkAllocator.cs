<<<<<<< HEAD
//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// 对象池分配器
/// </summary>
public class ChunkAllocator : Single<ChunkAllocator>
{
    Dictionary<string, Chunk> chunkList;

    public ChunkAllocator()
    {
        chunkList = new Dictionary<string, Chunk>();
    }
    
=======
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkAllocator : Single<ChunkAllocator>
{
>>>>>>> 5989ff2e6a0463b93b9d73e4e3bf34a1b9af819d
    /// <summary>
    /// 回收对象
    /// </summary>
    /// <param name="poolName"></param>
    /// <param name="obj"></param>
<<<<<<< HEAD
    public void Revert(string poolName, Object obj)
    {
        if (IsHavePool(poolName))
        {
            chunkList[poolName].ReverObj(obj);
        }
        
        else
        {
            Chunk chunk = new Chunk();
            chunk.ReverObj(obj);
            chunkList.Add(poolName, chunk);
        }
=======
    public void Revert(string poolName, object obj)
    {

>>>>>>> 5989ff2e6a0463b93b9d73e4e3bf34a1b9af819d
    }

    /// <summary>
    /// 获取对象
    /// </summary>
    /// <param name="poolName"></param>
    /// <returns></returns>
    private Object GetObject(string poolName)
    {
<<<<<<< HEAD
        if (!IsHavePool(poolName))
        {
            return new Object();
        }

        return chunkList[poolName].GetObj();

    }

    /// <summary>
    /// 从池子中获取对象
    /// </summary>
    /// <param name="poolName"></param>
    /// <param name="gameObject"></param>
    /// <param name="isFirst"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject GetGameObject(string poolName, GameObject gameObject, out bool isFirst, Transform parent = null)
    {
        GameObject go = null;
        if (!IsHavePool(poolName))
        {
            go = GameObject.Instantiate(gameObject);
            isFirst = true;
        }
        else
        {
            isFirst = !chunkList[poolName].IsHave;
            if (chunkList[poolName].IsHave)
            {
                go = chunkList[poolName].GetObj() as GameObject;
            }
            else
            {
                go = GameObject.Instantiate(gameObject);
            }
        }

        if (parent != null)
        {
            go.transform.SetParent(parent);
        }

        go.transform.position = Vector3.zero;
        go.transform.localScale = Vector3.one;
        go.SetActive(true);
        go.name = poolName;
        return go;
    }

    public T GetObj<T>(string poolName, string resName)
        where T:Object
    {
        if (!IsHavePool(poolName))
        {
            return ResLoad.Instance.LoadAsset<T>(resName);
        }
        return chunkList[poolName].GetObj() as T;
    }

    /// <summary>
    /// 获取预设体对象
    /// </summary>
    /// <param name="poolName"></param>
    /// <param name="resName"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject GetPrefab(string poolName, string resName, Transform parent = null)
    {
        GameObject go = null;
        if (IsHavePool(poolName))
            
        {   //没有就加载
            go = ResLoad.Instance.LoadPrefab(resName);
        }
        else
        {
            if (chunkList[poolName].IsHave)
                go = chunkList[poolName].GetObj() as GameObject;
            else
                go = ResLoad.Instance.LoadPrefab(resName);
        }
        if (parent != null)
        {
            go.transform.SetParent(parent);
        }

        go.transform.position = Vector3.zero;
        go.transform.localScale = Vector3.one;
        go.SetActive(true);
        go.name = poolName;
        return go;
    
    }

    /// <summary>
    /// 清空对象池
    /// </summary>
    /// <param name="poolName"></param>
    public void ClearPool(string poolName = "")
    {
        if (poolName == "")   
        {
            chunkList.Clear();
            return;
        }

        if (IsHavePool(poolName))
        {
            chunkList.Remove(poolName);
        }
    }

    /// <summary>
    /// 判断池子是否存在
    /// </summary>
    /// <param name="poolName"></param>
    private bool IsHavePool(string poolName)
    {
        return chunkList.ContainsKey(poolName);
=======
        return new Object();
>>>>>>> 5989ff2e6a0463b93b9d73e4e3bf34a1b9af819d
    }

}
