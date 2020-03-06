using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLogic : MonoBehaviour
{

    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip stepSound;



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
           // audio.clip = stepSound;
            audio.PlayOneShot(stepSound);
        }
    }

}
