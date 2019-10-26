using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistingScore : MonoBehaviour
{
    [SerializeField] List<string> scores;

    private void Start()
    {
        int count = FindObjectsOfType<PersistingScore>().Length;
        if (count > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore(string score)
    {
        scores.Add(score);
    }

    public void ClearScore()
    {
        scores.Clear();
    }

    public string getScores()
    {
        string formattedScores = "";
        for (int i = 0; i< scores.Count; i++)
        {
            formattedScores += "Level " + (i + 1).ToString() + ": " + scores[i] + "\n";
        }
        return formattedScores;
    }
}
