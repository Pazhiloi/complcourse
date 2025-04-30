using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MR
{
    public class CharacterBoat : MonoBehaviour
    {
        public CharacterBoatStats characterBoatStats;


        private void Awake() {
            characterBoatStats = GetComponent<CharacterBoatStats>();
        }
    }
}
