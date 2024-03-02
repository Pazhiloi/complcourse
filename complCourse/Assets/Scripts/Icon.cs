using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    public Transform target;

    private void Update() {
      Vector3 toTarget = target.position - transform.position;
      Vector3 toTargetXZ = new Vector3(toTarget.x, 0f, toTarget.z);
      transform.rotation = Quaternion.LookRotation(toTargetXZ);
    }
}
