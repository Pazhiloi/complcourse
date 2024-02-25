using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
  public Transform Target;

  private void Update()
  {

    if (Target)
    {
      transform.position = Target.position;
    }
  }
}
