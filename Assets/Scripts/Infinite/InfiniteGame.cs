using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGame : MonoBehaviour
{
    [SerializeField] GameObject[] typeBlocks = null;
    [SerializeField] int level = 0;
    CheckWinI gameBoard = null;
    float gameTimer = 0f;
    float timeAppearNew = 4f;
    float addNewWaitTimer = 0f;
    int avaiableBlockTypes = 1;

    void Start()
    {
        gameBoard = FindObjectOfType<CheckWinI>();
        _ = Instantiate(typeBlocks[0], new Vector3(Random.Range(0f, 16f), Random.Range(4f, 11f), 0f), transform.rotation);
    }

    void Update()
    {
        addNewWaitTimer += Time.deltaTime;
        if(addNewWaitTimer > timeAppearNew)
        {
            MakeItHarder();
            addNewWaitTimer = 0f;
            _ = Instantiate(typeBlocks[Random.Range(0, avaiableBlockTypes)], new Vector3(Random.Range(0f, 16f), Random.Range(4f, 11f), 0f), transform.rotation);
        }
        gameTimer = gameBoard.getTimer();
    }

    private void MakeItHarder()
    {
        if(level <= 27)
        {
            level++;
            timeAppearNew -= 0.1f;
        }
        if(level == 10 || level == 20)
        {
            gameBoard.setMaxBlocks(level + 10);
            avaiableBlockTypes++;
        }
    }
}
