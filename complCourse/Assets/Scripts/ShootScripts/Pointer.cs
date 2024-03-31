using UnityEngine;

public class Pointer : MonoBehaviour
{
  public Transform Aim;
  public Camera PlayerCamera;

  float distance;
  Vector3 point;
  Vector3 toAim;
  private Ray ray;
  private Plane plane;

  private void LateUpdate()
  {
    ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

    Debug.DrawRay(ray.origin, ray.direction * 50f, Color.yellow);
    plane = new Plane(-Vector3.forward, Vector3.zero);

    plane.Raycast(ray, out distance);
    point = ray.GetPoint(distance);

    Aim.position = point;

    toAim = Aim.position - transform.position;
    transform.rotation = Quaternion.LookRotation(toAim);
  }
}
