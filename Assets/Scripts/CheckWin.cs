using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckWin : MonoBehaviour
{
    [SerializeField] Canvas canvas = null;
    [SerializeField] string sceneName = null;
    [SerializeField] AudioClip[] victoryClip = null;
    [SerializeField] int activeBlocks = 0;
    Text levelCompleteText = null;
    Text timer = null;
    Button nextLevelButton = null;
    Button quitButton = null;
    bool once = false;

    private float update;

    public void addBlock(){
        activeBlocks++;
    }

    public void removeBlock(){
        activeBlocks--;
    }

    private void activeWinFields(bool b){
        nextLevelButton.gameObject.SetActive(b);
        levelCompleteText.gameObject.SetActive(b);
    }

    private void Start() {
        Time.timeScale = 1f;

        levelCompleteText = canvas.transform.Find("LevelCompleteText").GetComponent<Text>();
        timer = canvas.transform.Find("Timer").GetComponent<Text>();
        nextLevelButton = canvas.transform.Find("nextLevelButton").GetComponent<Button>();
        quitButton = canvas.transform.Find("gameOverButton").GetComponent<Button>();


        nextLevelButton.onClick.AddListener(delegate { SceneManager.LoadScene(sceneName);} );
        quitButton.gameObject.SetActive(false);
        activeWinFields(false);
    }

    void Update(){
        update += Time.deltaTime;
        timer.text = update.ToString("F3");
        if(activeBlocks == 0 && update > 1f){
            if(once == false){
                once = true;
                AudioSource.PlayClipAtPoint(victoryClip[Random.Range(0, victoryClip.Length)], Camera.main.transform.position);
                
                PersistingScore actualScore = FindObjectOfType<PersistingScore>();
                if(actualScore != null)
                    actualScore.AddScore(update.ToString("F3"));
            }
            Time.timeScale = 0f;
            if(sceneName != ""){
                activeWinFields(true);
            }

        }
    }
}
