using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public float LerpRate;

    private void Update() {
      transform.position = Vector3.Lerp(transform.position, target.position, LerpRate * Time.deltaTime);
    }
}
