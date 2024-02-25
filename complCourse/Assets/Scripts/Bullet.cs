using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    Bomb bomb = other.GetComponent<Bomb>();
    if (bomb)
    {
      bomb.Die();
      Destroy(gameObject);
    }
  }
}
