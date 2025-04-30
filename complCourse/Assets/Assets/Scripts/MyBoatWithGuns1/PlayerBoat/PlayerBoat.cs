using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MR
{
    public class PlayerBoat : CharacterBoat
    {
       PlayerBoatStats playerBoatStats;

          private void Awake() {
              playerBoatStats = GetComponent<PlayerBoatStats>();
          }
    }
   
}
