using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Player))]
public class PlayerStats : MonoBehaviour, IAlive
{
    public const int V = 10;
    [SerializeField] private Player player;
    [SerializeField] Equipment equipment;


   

    [Header("Bars")]
    public HealthBar healthBar;
    public float healthPoint;

    [Header("Player atribute")]
    public float defence;
    public float attackBase;
    public float magicAmplify;

    public float hPRegen = 0;
    public float strengh = V;
    public float agility = V;
    public float intelligence = V;

    public List<AtributeOfItem> atributeOfItems;

    private void Awake()
    {
        atributeOfItems = new List<AtributeOfItem>();
        foreach(TypeOfAtribute elem in Enum.GetValues(typeof(TypeOfAtribute)))
        {
            atributeOfItems.Add(new AtributeOfItem(elem, 0));
        }
        UpdateStats();
    }

    private void UpdateStats()
    {
        player.damage = attackBase + strengh + atributeOfItems[(int)TypeOfAtribute.Attack].value;
        defence = agility + atributeOfItems[(int)TypeOfAtribute.Defence].value;
        magicAmplify = intelligence + atributeOfItems[(int)TypeOfAtribute.Defence].value;
    }

    private void Start()
    {
        healthBar.MaxHealthPoint = healthPoint;
        healthBar.currentValue = healthPoint;
        equipment.Equipmting += () => RecalculationValueAdd();
        equipment.UnEquipmting += () => RecalculationValueMinus();
    }

    private void RecalculationValueAdd() 
    {
        if (equipment.EquipmentSlot.item != null)
        {
            foreach (AtributeOfItem atribute in equipment.EquipmentSlot.item.atributes)
            {
                atributeOfItems.Find(i => i.atribute == atribute.atribute).value += atribute.value;
            }
        }
        UpdateStats();
       
    }
    private void RecalculationValueMinus()
    {
        if (equipment.EquipmentSlot.item != null)
        {
            foreach (AtributeOfItem atribute in equipment.EquipmentSlot.item.atributes)
            {
                atributeOfItems.Find(i => i.atribute == atribute.atribute).value -= atribute.value;
            }
        }
        UpdateStats();
    }

    public void TakeDamage(float damage)
    {

        healthBar.MinusCurrentValue(MultiplayerDamage(damage));
        if (healthBar.currentValue == 0)
        {
            player.HealthLevelZero();
        }
    }

    private float MultiplayerDamage(float damage) {
        return (damage * (1 - ((0.052f * defence) / (0.9f + 0.048f * Math.Abs(defence)))));
    }
}
