using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float move;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private string enemy;
    [SerializeField]  private float damage;
    [SerializeField] private string creator;

    public float Move { set => move = value; }
    public float Speed { set => speed = value; }
    public string Enemy { set => enemy = value; }
    public float Damage { set => damage = value; }
    public string Creator { set => creator = value; }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag(enemy)) collider.GetComponent<IAlive>().TakeDamage(-damage);
     
        if(!collider.CompareTag(creator)) Destroy(gameObject);
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }
}
