using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float upperLimit = 4.25f;
    [SerializeField] float lowerLimit = -4.25f;
    [SerializeField] bool tracksRight = true;

    Ball target;

    void Update()
    {
        if (target == null)
        {
            target = FindAnyObjectByType<Ball>();
        }
        if (target == null)
        {
            return;
        }

        float x = target.GetComponent<Rigidbody2D>().linearVelocity.x;
        bool incoming = tracksRight ? x > 0f : x < 0f;
        if (!incoming)
        {
            return;
        }

        Vector3 position = transform.position;
        position.y = Mathf.MoveTowards(position.y, target.transform.position.y, speed * Time.deltaTime);
        position.y = Mathf.Clamp(position.y, lowerLimit, upperLimit);
        transform.position = position;
    }
}
