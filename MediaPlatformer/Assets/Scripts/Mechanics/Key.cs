using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class Key : MonoBehaviour
    {
        [HideInInspector]
        public bool pickedUp = false;

        Vector3 startPos, endPos;

        private void Start()
        {
            startPos = transform.position;
            endPos = startPos + new Vector3(0f, .2f, 0f);
            StartCoroutine(BobbingCoroutine());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
                pickedUp = true;
        }

        IEnumerator BobbingCoroutine()
        {
            while (true)
            {
                float elapsedTime = 0f;
                while (elapsedTime <= 1f)
                {
                    transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0f, 1f, elapsedTime));
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                transform.position = endPos;
                Vector3 tmp = startPos;
                startPos = endPos;
                endPos = tmp;
            }
        }
    }
}
