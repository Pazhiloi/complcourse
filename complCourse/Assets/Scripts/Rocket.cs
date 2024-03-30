using UnityEngine;

public class Rocket : MonoBehaviour
{
  public float Speed;
  public float RotationSpeed;
  private Transform _playerTransform;

  Vector3 toPlayer;
  Quaternion targetRotation;

  private void Start()
  {
    _playerTransform = FindObjectOfType<PlayerMove>().transform;
  }


  private void Update()
  {
    transform.position += Time.deltaTime * transform.forward * Speed;
    toPlayer = _playerTransform.position - transform.position;
    targetRotation = Quaternion.LookRotation(toPlayer , Vector3.forward);

    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
  }
}
