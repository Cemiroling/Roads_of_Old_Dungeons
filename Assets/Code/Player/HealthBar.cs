using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    [SerializeField] private Image _healthBar;
    private float current;
    private float maxHealthPoint;

    public void Start()
    {
        maxHealthPoint = 100;
        current = 100;
    }

    public float currentValue
    {
        get {return current;}
        set {current = value;}
    }

    public float MaxHealthPoint { get => maxHealthPoint; set => maxHealthPoint = value; }
    void Update()
    {
        if (current < 0)
            current = 0;
        if (current > maxHealthPoint)
            current = maxHealthPoint;
        _healthBar.gameObject.transform.localScale = new Vector3(current / maxHealthPoint, 1, 1);

    }
    public  void AdjustCurrentValue(float adjust)
    {
        current += adjust;
    }
    
    public  void MinusCurrentValue(float adjust)
    {
        current -= adjust;
    }

}