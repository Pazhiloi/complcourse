using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace MR
{
  public class EnemyBoat : CharacterBoat
  {
    EnemyBoatStats enemyBoatStats;
    private void Awake()
    {
      enemyBoatStats = GetComponent<EnemyBoatStats>();
    }

  }
}
