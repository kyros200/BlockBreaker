using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    [SerializeField] Text TextGameOver = null;
    [SerializeField] Button ButtonGameOver = null;

    public void StartGame(){
        SceneManager.LoadScene("Intro");
    }

    void Start () {
        TextGameOver.text = "Thanks for Playing!";
        ButtonGameOver.GetComponentInChildren<Text>().text = "Main Menu";
        ButtonGameOver.onClick.AddListener(delegate { StartGame(); });
    }
	
	// Update is called once per frame
	void Update () {
	}
}