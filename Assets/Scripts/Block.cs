using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip[] destroyClip = null;
    CheckWin level;

    private void Start() {
        level = FindObjectOfType<CheckWin>();
        level.addBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        level.removeBlock();
        AudioSource.PlayClipAtPoint(destroyClip[Random.Range(0, destroyClip.Length)], Camera.main.transform.position);
        Destroy(gameObject);
    }
}
