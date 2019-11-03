using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float CameraWidthSize = 16f;
    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 15f;

    // Update is called once per frame
    void Update()
    {
        //if(Time.timeScale != 0f){
        //    float position = Input.GetTouch(0).position.x;
        //    float mousePosition = Input.mousePosition.x / Screen.width * CameraWidthSize;
        //    Vector2 paddlePosition = new Vector2(Mathf.Clamp(mousePosition, xMin, xMax), transform.position.y);
        //    transform.position = paddlePosition;
        //}

        if (Time.timeScale != 0f)
        {
            float touchPosition = Input.GetTouch(0).position.x / Screen.width * CameraWidthSize;
            Vector2 paddlePosition = new Vector2(Mathf.Clamp(touchPosition, xMin, xMax), transform.position.y);
            transform.position = paddlePosition;
        }
    }

}
