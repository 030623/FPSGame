using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMark : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
