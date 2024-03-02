using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
  public Transform playerTransform;
  void Update()
  {
    transform.position = playerTransform.position;
  }
}
