using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
  [SerializeField] Transform target;

  private void Update()
  {
    MoveCamera();
  }

  private void MoveCamera()
  {
    transform.position = target.position;
  }
}
