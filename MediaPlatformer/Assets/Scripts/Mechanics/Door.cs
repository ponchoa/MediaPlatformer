using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class Door : MonoBehaviour
    {
        public Key key;

        private void Start()
        {
            if (key == null)
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (key.pickedUp)
                Destroy(gameObject);
        }
    }
}
