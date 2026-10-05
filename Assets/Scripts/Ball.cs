using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed = 8f;
    [SerializeField] AudioClip bounceClip;
    Rigidbody2D rb;
    Collider2D col;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    public void Serve()
    {
        bool serveRight = Random.value > 0.5f;
        float angle = serveRight ? Random.Range(45f, 135f) : Random.Range(225f, 315f);

        float rad = angle * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Sin(rad), Mathf.Cos(rad));
        rb.linearVelocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        AudioSource.PlayClipAtPoint(bounceClip, transform.position);
    }
}
