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
        GetComponent<AudioSource>().PlayOneShot(hitClip[Random.Range(0, hitClip.Length)]);
    }
}