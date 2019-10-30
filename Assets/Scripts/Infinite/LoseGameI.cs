using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseGameI : MonoBehaviour
{

    [SerializeField] BallI ball = null;

    private void OnTriggerEnter2D(Collider2D collision){
        ball.ResetBall();
    }

}
