using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

    [SerializeField] Text TextIntro = null;
    [SerializeField] Button ButtonStart = null;

    public void StartGame(){
        SceneManager.LoadScene("Level1");
    }

    void Start () {
        TextIntro.text = "Block Breaker";
        ButtonStart.GetComponentInChildren<Text>().text = "Start Game";
        ButtonStart.onClick.AddListener(delegate { StartGame(); });
    }
}