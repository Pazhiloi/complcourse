using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
  public GameObject CoinPrefab;
  public GameObject BombPrefab;


  private void Start()
  {
    for (int i = 0; i < 100; i++)
    {
      if (Random.Range(0, 3) == 0)
      {
        Vector3 pos = new Vector3(i, Random.Range(-15f, 15f), 0);
        if (Random.Range(0, 3) == 0)
        {
          Instantiate(BombPrefab, pos, Quaternion.identity);
        }
        else
        {
          Instantiate(CoinPrefab, pos, Quaternion.identity);
        }
      }
    }
  }
}
