using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using Unity.AppUI.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Ball ballPrefab;
    [SerializeField] float countdown = 2f;

    [SerializeField] TMP_Text leftScoreText;
    [SerializeField] TMP_Text rightScoreText;
    [SerializeField] GameObject menu;


    Ball liveBall;
    [SerializeField] AudioClip scoreClip;
    int rightPlayerScore;
    int leftPlayerScore;


    IEnumerator Start()
    {
        ShowScore();
        yield return new WaitForSeconds(countdown);
        SpawnBall();
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            menu.SetActive(!menu.activeSelf);
        }
    }

    public void SpawnBall()
    {
        if (liveBall != null) Destroy(liveBall.gameObject);

        liveBall = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
        liveBall.Serve();
    }

    public void Score(bool rightPlayerScored)
    {
        if (rightPlayerScored) rightPlayerScore++;
        else leftPlayerScore++;

        AudioSource.PlayClipAtPoint(scoreClip, Vector3.zero);

        Debug.Log(rightPlayerScored ? $"Right scored: {rightPlayerScore}" : $"Left scored: {leftPlayerScore}");
        ShowScore();
        SpawnBall();
    }

    void ShowScore()
    {
        leftScoreText.text = leftPlayerScore.ToString();
        rightScoreText.text = rightPlayerScore.ToString();
    }

    public void ResetMatch()
    {
        leftPlayerScore = 0;
        rightPlayerScore = 0;
        ShowScore();
        SpawnBall();
        menu.SetActive(false);
    }
}
