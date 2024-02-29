using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
  public GameObject CoinPrefab;

  public List<GameObject> ObjectsList = new List<GameObject>();

  private void Start()
  {
    for (int i = 0; i < 50; i++)
    {
      Vector3 position = new Vector3(Random.Range(-20f, 20f), 0.5f, Random.Range(-20f, 20f));
      GameObject newCoin = Instantiate(CoinPrefab, position, Quaternion.identity);
      ObjectsList.Add(newCoin);
    }
  }

}
