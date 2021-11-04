using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class FinishSystem : MonoBehaviour
{
    [SerializeField] UnityEvent finishEvent;
    [SerializeField] GameObject Generator;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Finish");
        finishEvent.Invoke();
        Destroy(Generator);
    }
}
