using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
  [SerializeField] Transform target;

  private void LateUpdate()
  {
    MoveCamera();
  }

  private void MoveCamera()
  {
    transform.position = target.position;
  }
}
