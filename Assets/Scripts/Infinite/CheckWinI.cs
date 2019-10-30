using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckWinI : MonoBehaviour
{
    [SerializeField] Canvas canvas = null;
    [SerializeField] string sceneName = null;
    [SerializeField] AudioClip[] victoryClip = null;
    [SerializeField] int activeBlocks = 0;
    Text levelCompleteText = null;
    Text blockCountText = null;
    Text timer = null;
    Button nextLevelButton = null;
    Button quitButton = null;
    bool once = false;
    int maxBlocks = 10;

    private float update;

    public void addBlock(){
        activeBlocks++;
    }

    public void removeBlock(){
        activeBlocks--;
    }

    public void setMaxBlocks(int newMax)
    {
        maxBlocks = newMax;
    }

    public float getTimer()
    {
        return update;
    }

    private void activeWinFields(bool b){
        nextLevelButton.gameObject.SetActive(b);
        levelCompleteText.gameObject.SetActive(b);
    }

    private void Start() {
        Time.timeScale = 1f;

        levelCompleteText = canvas.transform.Find("LevelCompleteText").GetComponent<Text>();

        blockCountText = canvas.transform.Find("CountText").GetComponent<Text>();

        timer = canvas.transform.Find("Timer").GetComponent<Text>();

        quitButton = canvas.transform.Find("gameOverButton").GetComponent<Button>();
        quitButton.gameObject.SetActive(false);

        nextLevelButton = canvas.transform.Find("nextLevelButton").GetComponent<Button>();
        nextLevelButton.onClick.AddListener(delegate { SceneManager.LoadScene(sceneName);} );
        activeWinFields(false);
    }

    void Update(){
        blockCountText.text = activeBlocks.ToString() + "/" + maxBlocks;
        update += Time.deltaTime;
        timer.text = update.ToString("F3");
        if (activeBlocks == maxBlocks)
        {
            if (once == false)
            {
                once = true;
                AudioSource.PlayClipAtPoint(victoryClip[Random.Range(0, victoryClip.Length)], Camera.main.transform.position);
            }
            Time.timeScale = 0f;
            if (sceneName != "")
            {
                activeWinFields(true);
            }
        }
    }
}
