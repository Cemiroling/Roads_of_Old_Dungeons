using UnityEngine;

public class WallLogic : MonoBehaviour
{
    [SerializeField] private string playerTag;
    private Player playerTemp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(playerTag))
        {
            playerTemp = collision.collider.GetComponent<Player>();
            if (!playerTemp.isGround())
            {
                playerTemp.IsBlockMove = true;
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(playerTag))
        {
            playerTemp.IsBlockMove = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(playerTag))
        {
            if (playerTemp.isGround())
                playerTemp.IsBlockMove = false;
            else
                playerTemp.IsBlockMove = true;
        }
    }
}
