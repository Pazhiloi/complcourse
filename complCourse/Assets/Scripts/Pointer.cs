using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
  public CoinManager coinManager;

  public Coin ClosestCoin;

  private void Update() {
    ClosestCoin = coinManager.GetClosest(transform.position);
    Debug.DrawLine(transform.position, ClosestCoin.transform.position, Color.red);
  }
}
