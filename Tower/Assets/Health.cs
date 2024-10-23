using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Atributos")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyWorth = 50;




    public void TakeDamage( int dmg)
    {
        hitPoints -= dmg;


        if (hitPoints <= 0)
        {
            CirclieSpawn.onEnemyDestroy.Invoke();
GameManager.Instance.IncreaseCurrency(currencyWorth);
Destroy(gameObject);
        }
    }


}
