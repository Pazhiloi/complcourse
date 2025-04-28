using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MR
{
    public class CannonRotation : MonoBehaviour
    {
    public float horizontalRotationSpeed = 5f;
    public float verticalRotationSpeed = 5f;
    public Transform turretBase;      // Основа гармати для горизонтального повороту
    public Transform cannonPivot;    // Точка повороту для вертикального нахилу гармати
    public float minVerticalAngle = -20f; // Мінімальний кут нахилу вниз
    public float maxVerticalAngle = 30f;  // Максимальний кут нахилу вгору

    private float currentVerticalAngle = 0f;

    void Update()
    {
      // Горизонтальний поворот (навколо осі Y)
      float mouseXInput = Input.GetAxis("Mouse X");
      float horizontalRotationAmount = mouseXInput * horizontalRotationSpeed;
      turretBase.Rotate(Vector3.up * horizontalRotationAmount);

      // Вертикальний нахил (навколо локальної осі X cannonPivot)
      float mouseYInput = Input.GetAxis("Mouse Y");
      float verticalRotationAmount = -mouseYInput * verticalRotationSpeed; // Інвертуємо для інтуїтивного керування

      // Обчислюємо новий вертикальний кут
      currentVerticalAngle += verticalRotationAmount;
      currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, minVerticalAngle, maxVerticalAngle);

      // Застосовуємо поворот до точки повороту гармати
      cannonPivot.localEulerAngles = new Vector3(currentVerticalAngle, 0f, 0f);
    }
}

}