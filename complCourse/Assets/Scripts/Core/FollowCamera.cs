using UnityEngine;
namespace RPG.Core
{
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
}
