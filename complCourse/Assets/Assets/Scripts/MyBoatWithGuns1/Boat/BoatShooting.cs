using System.Collections.Generic;
using UnityEngine;
namespace MR
{
  public class BoatShooting : MonoBehaviour
{
  private List<FindCannonObject> cannons = new List<FindCannonObject>();

  void Start()
  {
    FindAllCannons();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      ShootAllCannons();
    }
  }

  // Метод для пошуку всіх гармат
  private void FindAllCannons()
  {
    FindCannonObject[] foundCannons = GetComponentsInChildren<FindCannonObject>();

    cannons.AddRange(foundCannons);

    Debug.Log($"Знайдено {cannons.Count} гармат на кораблі.");
  }

  private void ShootAllCannons()
  {
    if (cannons.Count > 0)
    {
      foreach (FindCannonObject cannon in cannons)
      {
        var cannonScript = cannon.GetComponent<CannonShooting>();
       
        cannonScript.HandleShooting();
      }
      Debug.Log("Вистріл з усіх гармат!");
    }
    else
    {
      Debug.LogWarning("На кораблі не знайдено жодної гармати для стрільби.");
    }
  }
}
}