﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class FinishSystem : MonoBehaviour
{
    [SerializeField] UnityEvent finishEvent;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            finishEvent.Invoke();
        }
    }
}