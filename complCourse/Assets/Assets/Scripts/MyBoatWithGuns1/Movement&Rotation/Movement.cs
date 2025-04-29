using UnityEngine;

namespace MR
{
    public class Movement : MonoBehaviour
    {
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public Rigidbody rb;

    protected virtual void Awake()
    {
      rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update(){
      // Отримуємо вхідні дані для руху вперед/назад
      float verticalInput = Input.GetAxis("Vertical");

      // Отримуємо вхідні дані для повороту вліво/вправо
      float horizontalInput = Input.GetAxis("Horizontal");

      // Розраховуємо вектор руху
      Vector3 moveDirection = transform.forward * verticalInput * moveSpeed * Time.deltaTime;

      // Застосовуємо рух до об'єкта
      rb.MovePosition(rb.position + moveDirection);

      // Розраховуємо кут повороту
      float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

      // Застосовуємо поворот до об'єкта
      Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotationAmount);
      rb.MoveRotation(rb.rotation * deltaRotation);
    }
  }
}
