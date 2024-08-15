using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    private bool isDestroy;
    public UnityEvent destroyEvent = new UnityEvent();

    public void OnEnable()
    {
        isDestroy = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && !isDestroy)
        {
            isDestroy = true;
            destroyEvent?.Invoke();
        }
    }
}
