using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndPoint : MonoBehaviour
{
    SphereCollider sphereCollider;

    public UnityEvent OnPlayerEnter;
    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Player has entered the end point");
            OnPlayerEnter.Invoke();
        }
    }
}
