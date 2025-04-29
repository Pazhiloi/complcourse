using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MR
{
    public class CannonCamera : MonoBehaviour
    {
    public Transform turretTransform; // Посилання на Transform гармати
    public Vector3 positionOffset = Vector3.zero; // Зміщення позиції камери відносно гармати
    public Vector3 rotationOffset = Vector3.zero; // Зміщення повороту камери відносно гармати

    void LateUpdate()
    {
      if (turretTransform != null)
      {
        // Розраховуємо цільову позицію камери
        Vector3 targetPosition = turretTransform.position + turretTransform.rotation * positionOffset;
        transform.position = targetPosition;

        // Розраховуємо цільоний поворот камери
        Quaternion targetRotation = turretTransform.rotation * Quaternion.Euler(rotationOffset);
        transform.rotation = targetRotation;
      }
      else
      {
        Debug.LogError("Turret Transform не призначено для камери!");
      }
    }
  }
}
