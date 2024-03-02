using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
  public GameObject CoinPrefab;

  public List<Coin> CoinsList = new List<Coin>();

  public Text CoinsText;

  private void Start()
  {
    for (int i = 0; i < 50; i++)
    {
      Vector3 position = new Vector3(Random.Range(-20f, 20f), 0.5f, Random.Range(-20f, 20f));
      GameObject newCoin = Instantiate(CoinPrefab, position, Quaternion.identity);
      CoinsList.Add(newCoin.GetComponent<Coin>());
    }
    UpdateText();
  }


  public void CollectCoin(Coin coin){
    CoinsList.Remove(coin);
    Destroy(coin.gameObject);

    UpdateText();
  }


  private void UpdateText(){
    CoinsText.text = "Coins Remain " + CoinsList.Count.ToString();
  }

}
