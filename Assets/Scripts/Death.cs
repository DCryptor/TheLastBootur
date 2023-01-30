using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace deatherror
{
    public class Death : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterControl>())
            {
                CharacterControl player = other.GetComponent<CharacterControl>();
                player.death = true;
            }
        }
    }
}
