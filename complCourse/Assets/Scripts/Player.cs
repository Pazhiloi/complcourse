using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public CoinManager coinManager;
  private void OnTriggerEnter(Collider other)
  {
    if (other.GetComponent<Coin>())
    {
      coinManager.CollectCoin(other.GetComponent<Coin>());
    }
  }
}
