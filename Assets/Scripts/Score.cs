using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] Text TextScores = null;
    [SerializeField] Button goToIntroButton = null;
    PersistingScore scores;

    void Start()
    {
        goToIntroButton.onClick.AddListener(delegate { ButtonPressed(); });

        scores = FindObjectOfType<PersistingScore>();
        string formattedScore = scores.getScores();
        TextScores.text = formattedScore;
    }

    void ButtonPressed()
    {
        scores.ClearScore();
        SceneManager.LoadScene("Intro");
    }
}
