using UnityEngine;

namespace MR
{
    public class Rotation : MonoBehaviour
    {
    public float horizontalRotationSpeed = 5f;
    public float verticalRotationSpeed = 5f;
    public Transform horizontalBase;      // Основа гармати для горизонтального повороту
    public Transform verticalPivot;    // Точка повороту для вертикального нахилу гармати
    public float minVerticalAngle = -20f; // Мінімальний кут нахилу вниз
    public float maxVerticalAngle = 30f;
    protected float currentVerticalAngle = 0f;

   protected virtual void Update()
    {
      // Горизонтальний поворот (навколо осі Y)
      float mouseXInput = Input.GetAxis("Mouse X");
      float horizontalRotationAmount = mouseXInput * horizontalRotationSpeed;
      horizontalBase.Rotate(Vector3.up * horizontalRotationAmount);

      // Вертикальний нахил (навколо локальної осі X cannonPivot)
      float mouseYInput = Input.GetAxis("Mouse Y");
      float verticalRotationAmount = -mouseYInput * verticalRotationSpeed; // Інвертуємо для інтуїтивного керування

      // Обчислюємо новий вертикальний кут
      currentVerticalAngle += verticalRotationAmount;
      currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, minVerticalAngle, maxVerticalAngle);

      // Застосовуємо поворот до точки повороту гармати
      verticalPivot.localEulerAngles = new Vector3(currentVerticalAngle, 0f, 0f);
    }
  }
}
