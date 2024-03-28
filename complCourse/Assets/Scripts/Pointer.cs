using UnityEngine;

public class Pointer : MonoBehaviour
{
  public Transform Aim;
  public Camera PlayerCamera;

  float distance;
  Vector3 point;
  private Ray ray;
  private Plane plane;

  private void Update()
  {
    ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

    Debug.DrawRay(ray.origin, ray.direction * 50f, Color.yellow);
    plane = new Plane(-Vector3.forward, Vector3.zero);

    plane.Raycast(ray, out distance);
    point = ray.GetPoint(distance);

    Aim.position = point;
  }
}
