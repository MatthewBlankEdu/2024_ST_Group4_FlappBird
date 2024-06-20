using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float JumpForce;

    public static bool HasStarted;
    public static bool GameOver;

    public int Points;

    public GameObject GameOverScreen;
    public TextMeshProUGUI PointsTextField;
    public TextMeshProUGUI HighscorePointsTextField;

    public Animator Anim;
    public AudioSource Source;

    public AudioClip JumpSfx;
    public AudioClip ScoreSfx;
    public AudioClip DeathSfx;

    private void PlaySound(AudioClip clip)
    {
        Source.clip = clip;
        Source.Play();
    }

    public void Restart()
    {
        SceneManager.LoadScene("FlappyBird");
    }

    // Start is called before the first frame update
    void Start()
    {
        HasStarted = false;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        PointsTextField.text = Points.ToString();

        if (GameOver)
            return;

        if (Input.GetButtonDown("Jump"))
        {
            PlaySound(JumpSfx);
            Anim.SetTrigger("FlapWings");

            if (!HasStarted)
            {
                HasStarted = true;
                rb2D.gravityScale = 1;
            }

            rb2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOverScreen.SetActive(true);
        GameOver = true;

        PlaySound(DeathSfx);

        if (Points > PlayerPrefs.GetInt("Highscore"))
        {
            HighscorePointsTextField.text = Points.ToString();
            PlayerPrefs.SetInt("Highscore", Points);
        }
        else
        {
            HighscorePointsTextField.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Point"))
        {
            Points++;

            PlaySound(ScoreSfx);
        }
    }

}
