using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle = null;
    [SerializeField] float xVel = 2f;
    [SerializeField] float yVel = 15f;
    [SerializeField] AudioClip[] hitClip = null;
    [SerializeField] AudioClip[] startClip = null;
    
    Vector2 distanceBallPaddle;
    bool hasStarted;

    // Start is called before the first frame update
    void Start() {
        distanceBallPaddle = transform.position - paddle.transform.position;
        hasStarted = false;
    }

    // Update is called once per frame
    void Update() {
        if (!hasStarted){
            LockedBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockedBallToPaddle() {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + distanceBallPaddle;
    }

    private void LaunchOnMouseClick() {
        if(Input.GetMouseButtonUp(0)){
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVel, yVel);
            GetComponent<AudioSource>().PlayOneShot(startClip[Random.Range(0, startClip.Length)]);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        Rigidbody2D ballRigidBody = GetComponent<Rigidbody2D>();

        LimitVelocity(ballRigidBody, 12f);
        AddBurstWhenStruck(ballRigidBody);

        GetComponent<AudioSource>().PlayOneShot(hitClip[Random.Range(0, hitClip.Length)]);
    }

    private static void AddBurstWhenStruck(Rigidbody2D ballRigidBody)
    {
        if (ballRigidBody.velocity.y >= -0.3f && ballRigidBody.velocity.y <= 0.3f)
        {
            ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, 0.5f);
        }
    }

    private static void LimitVelocity(Rigidbody2D ballRigidBody, float limit)
    {
        if (ballRigidBody.velocity.x >= limit)
        {
            ballRigidBody.velocity = new Vector2(limit, ballRigidBody.velocity.y);
        }
        else if (ballRigidBody.velocity.x <= -limit)
        {
            ballRigidBody.velocity = new Vector2(-limit, ballRigidBody.velocity.y);
        }

        if (ballRigidBody.velocity.y >= limit)
        {
            ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, limit);
        }
        else if (ballRigidBody.velocity.y <= -limit)
        {
            ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, -limit);
        }
    }
}