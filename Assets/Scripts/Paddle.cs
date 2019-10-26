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
        if(Time.timeScale != 0f){
            float mousePosition = Input.mousePosition.x / Screen.width * CameraWidthSize;
            Vector2 paddlePosition = new Vector2(Mathf.Clamp(mousePosition, xMin, xMax), transform.position.y);
            transform.position = paddlePosition;
        }
    }

}
