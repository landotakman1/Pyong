using UnityEngine;

public class ScoreWall : MonoBehaviour
{
    [SerializeField] GameManager manager;
    [SerializeField] bool rightPlayerScores;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<Ball>())
        {
            return;
        }

        manager.Score(rightPlayerScores);
    }
}
