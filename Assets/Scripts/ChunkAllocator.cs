using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkAllocator : Single<ChunkAllocator>
{
    /// <summary>
    /// 回收对象
    /// </summary>
    /// <param name="poolName"></param>
    /// <param name="obj"></param>
    public void Revert(string poolName, object obj)
    {

    }

    /// <summary>
    /// 获取对象
    /// </summary>
    /// <param name="poolName"></param>
    /// <returns></returns>
    private Object GetObject(string poolName)
    {
        return new Object();
    }

}
