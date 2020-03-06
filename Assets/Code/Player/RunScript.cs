using UnityEngine;


[RequireComponent (typeof(Player))] 

public class RunScript : MonoBehaviour
{

    public Player player;

    public bool onStairs = false;

    public StraitsPlatform StraitsPlatform { get; set; }


    private void Start()
    {
        
        player = GetComponent<Player>();
       
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            if (onStairs)
            {
                Debug.Log("Up/Down");
                player.Stairs(StraitsPlatform);
            }
            if (Input.GetKeyDown(KeyCode.Space))
                player.Jump();
            if (Input.GetKeyDown(KeyCode.F))
                player.Attack();
            player.Move();
            player.Damage();
            player.Health();
        }
       
    }

    private void FixedUpdate()
    {
        player.Damage();
    }


}
