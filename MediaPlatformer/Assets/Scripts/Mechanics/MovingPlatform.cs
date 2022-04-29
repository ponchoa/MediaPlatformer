using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class MovingPlatform : MonoBehaviour
    {
        public PatrolPath path;
        public float speed = 2f;

        void Start()
        {
            if (path != null)
            {
                transform.position = new Vector3(path.startPosition.x + path.transform.position.x, path.startPosition.y + path.transform.position.y, transform.position.z);
                StartCoroutine(MoveAlongPathCoroutine());
            }
        }

        IEnumerator MoveAlongPathCoroutine()
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = new Vector3(path.endPosition.x + path.transform.position.x, path.endPosition.y + path.transform.position.y, transform.position.z);
            float duration = Vector3.Distance(startPos, endPos) / speed;
            while (true)
            {
                float elapsedTime = 0f;
                while (elapsedTime <= duration)
                {
                    float time = Mathf.SmoothStep(0f, 1f, elapsedTime / duration);
                    Vector3 newPos = Vector3.Lerp(startPos, endPos, time);
                    transform.position = newPos;
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                transform.position = endPos;
                Vector3 tmp = endPos;
                endPos = startPos;
                startPos = tmp;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
            {
                //collision.transform.parent = transform;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
            {
                collision.transform.parent = null;
            }
        }
    }
}
