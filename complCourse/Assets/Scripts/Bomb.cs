using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject DieEffectPrefab;
    public void Die(){
      Instantiate(DieEffectPrefab, transform.position, Quaternion.identity);
      Destroy(gameObject);
    }
}
