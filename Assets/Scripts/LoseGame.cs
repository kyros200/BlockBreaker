using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{
    [SerializeField] Canvas canvas = null;
    [SerializeField] string sceneName = null;
    [SerializeField] AudioClip[] deathClip = null;
    Text levelCompleteText = null;
    Button retryButton = null;
    Button quitButton = null;

    private void Start()
    {
        levelCompleteText = canvas.transform.Find("LevelCompleteText").GetComponent<Text>();
        retryButton = canvas.transform.Find("nextLevelButton").GetComponent<Button>();
        quitButton = canvas.transform.Find("gameOverButton").GetComponent<Button>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        AudioSource.PlayClipAtPoint(deathClip[Random.Range(0, deathClip.Length)], Camera.main.transform.position);
        Time.timeScale = 0f;

        levelCompleteText.text = "Game Over!";

        quitButton.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        levelCompleteText.gameObject.SetActive(true);

        quitButton.onClick.AddListener(delegate { SceneManager.LoadScene(sceneName);} );

        Scene actualScene = SceneManager.GetActiveScene();
        retryButton.GetComponentInChildren<Text>().text = "Retry Level";
        retryButton.onClick.AddListener(delegate { SceneManager.LoadScene(actualScene.name);} );
    }

}
