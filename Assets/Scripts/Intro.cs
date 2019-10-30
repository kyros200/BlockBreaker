using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

    [SerializeField] Text TextIntro = null;
    [SerializeField] Button ButtonStartNormal = null;
    [SerializeField] Button ButtonStartInfinite = null;

    public void StartNormalGame(){
        SceneManager.LoadScene("Level1");
    }
    
    public void StartInfiniteGame(){
        SceneManager.LoadScene("LevelI");
    }

    void Start () {
        TextIntro.text = "Block Breaker";

        ButtonStartNormal.GetComponentInChildren<Text>().text = "Normal Game";
        ButtonStartNormal.onClick.AddListener(delegate { StartNormalGame(); });

        ButtonStartInfinite.GetComponentInChildren<Text>().text = "Infinite Game";
        ButtonStartInfinite.onClick.AddListener(delegate { StartInfiniteGame(); });
    }
}