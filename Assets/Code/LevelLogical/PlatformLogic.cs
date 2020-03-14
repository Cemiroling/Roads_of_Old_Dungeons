using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformLogic : MonoBehaviour
{
    public GameObject platform;

    public PlatformEffector2D platformEffector2D;
    public GameObject triggerZone;

    private void Start()
    {
      /*  triggerZone.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(platform.gameObject.GetComponent<TilemapRenderer>().chunkSize.x + 2,
            platform.gameObject.GetComponent<TilemapRenderer>().chunkSize.y + 2);*/
      /*  triggerZone.gameObject.GetComponent<Transform>().transform.position = new Vector2(platform.transform.position.x,
            platform.transform.position.y - 1);*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        platformEffector2D.surfaceArc = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        platformEffector2D.surfaceArc = 180;
    }
}