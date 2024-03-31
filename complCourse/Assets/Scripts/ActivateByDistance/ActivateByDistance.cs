using UnityEditor;
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
  public float DistanceToActivate = 20f;
  private bool _isActive = true; 
  private Activator _activator;

  private void Start(){
    _activator = FindObjectOfType<Activator>();
    _activator.ObjectsToActivate.Add(this);
  }

  public void CheckDistance(Vector3 playerPosition)
  {
    float distance = Vector3.Distance(transform.position, playerPosition);

    if (_isActive)
    {
      if (distance > DistanceToActivate + 2f)
      {
        Deactivate();
      }
    }
    else
    {

      if (distance < DistanceToActivate)
      {
        Activate();
      }
    }


  }
  public void Activate()
  {
    _isActive = true;
    gameObject.SetActive(true);
  }
  public void Deactivate()
  {
    _isActive = false;
    gameObject.SetActive(false);
  }

  private void OnDestroy() {
    _activator.ObjectsToActivate.Remove(this);
  }

  private void OnDrawGizmosSelected() {
    Handles.color = Color.grey;
    Handles.DrawWireDisc(transform.position, Vector3.forward, DistanceToActivate);
  }
}
