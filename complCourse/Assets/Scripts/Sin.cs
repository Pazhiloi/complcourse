using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sin : MonoBehaviour
{
    
    void Update()
    {
        transform.localPosition = new Vector3(0f, Mathf.Sin(Time.time), 0f);
    }
}
