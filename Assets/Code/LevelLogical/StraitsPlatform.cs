using UnityEngine;

public class StraitsPlatform : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;

    void Start()
    {
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    public void Climb(int derection)
    {
        boxCollider2D.size = new Vector2(boxCollider2D.size.x, boxCollider2D.size.y + derection);
    }

    public void Reset()
    {
        boxCollider2D.size = new Vector2(boxCollider2D.size.x, 0);
    }

}