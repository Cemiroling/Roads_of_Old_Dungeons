using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IAlive
{
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Animator _animatorController;
    private bool isFacingRight = true;
    private bool doubleJump = false;
    private bool isBlockMove = false;


    [Header("Передвижения игрока")]
    public float walkSpeed = 3;
    public float jumpForce = 10;
    public float speedUp;
    public float hOfPlayer;

    [Header("Bars")]
    public HealthBar healthBar;

    [Header("Маски")]
    public LayerMask enemy;
    public LayerMask ground;
    public string groundTag;



    [SerializeField] public ItemScene itemScene;
    [SerializeField] Text text;  
    [SerializeField] EquipmentManager equipmentManager;

    public bool IsBlockMove { set => isBlockMove = value; }

    public void Move()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _rigidbody.velocity = new Vector2(move * walkSpeed, _rigidbody.velocity.y);
        _animatorController.SetFloat("Speed", Mathf.Abs(move));     
        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
    }
    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animatorController = GetComponent<Animator>();
    }

    
    private void Flip()
    {
        
        isFacingRight = !isFacingRight;
   
        Vector3 theScale = _transform.localScale;
    
        theScale.x *= -1;
        
        _transform.localScale = theScale;
        
    }

    public bool isGround()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.down, hOfPlayer, ground + enemy);
        if (raycastHit2D)
            return true;
        else return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, new Vector2(0, -1*hOfPlayer));


    }

    public void Jump()
    {
        if (isGround())
        {
            _rigidbody.AddForce(_transform.up * jumpForce, ForceMode2D.Impulse);
            doubleJump = false;
        }
        else if(!doubleJump)
        {
            _rigidbody.AddForce(_transform.up * jumpForce, ForceMode2D.Impulse);
            doubleJump = true;
        }                 
    }

    public void ExitStraits()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    public void Attack()
    {
      _animatorController.SetBool("Attack", true);     
    }

    public void noAttack()
    {
        _animatorController.SetBool("Attack", false);
    }

    public void TakeDamage(float damage)
    {
        healthBar.AdjustCurrentValue(damage);

    }
    public void Damage()
    {
       // RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.);

    }



    public void Health()
    {
        if (healthBar.currentValue == 0)
        {
            _animatorController.SetBool("Death", true);
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void CastOn()
    {
        _animatorController.SetBool("Cast", false);
    }


    public void FallDown()
    {
        _rigidbody.AddForce(_transform.up * (-2), ForceMode2D.Impulse);
        if (isFacingRight)
            _rigidbody.velocity = new Vector2(-1*walkSpeed,  _rigidbody.velocity.y);
        else _rigidbody.velocity = new Vector2(1* walkSpeed, _rigidbody.velocity.y);

    }
}