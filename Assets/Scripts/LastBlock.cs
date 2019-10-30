using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBlock : MonoBehaviour
{
    [SerializeField] GameObject deathVFX = null;
    [SerializeField] AudioClip[] destroyClip = null;
    CheckWin level;

    private void Start() {
        level = FindObjectOfType<CheckWin>();
        level.addBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        level.removeBlock();
        //SFX
        AudioSource.PlayClipAtPoint(destroyClip[Random.Range(0, destroyClip.Length)], Camera.main.transform.position);
        //VFX
        if (deathVFX != null)
        {
            GameObject vfx = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(vfx, 1f);
        }

        Destroy(gameObject);
    }
}
