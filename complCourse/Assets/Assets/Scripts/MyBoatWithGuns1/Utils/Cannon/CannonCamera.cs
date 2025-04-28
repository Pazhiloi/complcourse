using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MR
{
    public class CannonCamera : MonoBehaviour
    {
    public Transform turretTransform; // Посилання на Transform гармати

    void LateUpdate()
    {
      if (turretTransform != null)
      {
        // Встановлюємо позицію камери в позицію гармати
        transform.position = turretTransform.position;

        // Встановлюємо поворот камери в поворот гармати
        transform.rotation = turretTransform.rotation;
      }
      else
      {
        Debug.LogError("Turret Transform не призначено для камери!");
      }
    }
  }
}
