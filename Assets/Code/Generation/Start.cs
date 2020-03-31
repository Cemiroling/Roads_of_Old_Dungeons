using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    Player player;

    public GameObject spawner;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        player.transform.position =  new Vector3(spawner.transform.position.x, spawner.transform.position.y,0);
    }
}
