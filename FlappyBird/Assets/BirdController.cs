using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float JumpForce;

    public static bool HasStarted;
    public static bool GameOver;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
            return;

        if (Input.GetButtonDown("Jump"))
        {
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
        GameOver = true;
    }
}
