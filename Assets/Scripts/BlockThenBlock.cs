using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockThenBlock : MonoBehaviour
{
    [SerializeField] GameObject nextBlock = null;
    [SerializeField] AudioClip[] destroyClip = null;
    CheckWin level;
    CheckWinI levelI;

    private void Start()
    {
        level = FindObjectOfType<CheckWin>();
        levelI = FindObjectOfType<CheckWinI>();

        if(level != null)
        {
            level.addBlock();
        }
        else
        {
            levelI.addBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (level != null)
        {
            level.removeBlock();
        }
        else
        {
            levelI.removeBlock();
        }
        //SFX
        AudioSource.PlayClipAtPoint(destroyClip[Random.Range(0, destroyClip.Length)], Camera.main.transform.position);
        //VFX
        if (nextBlock != null)
        {
            _ = Instantiate(nextBlock, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}
