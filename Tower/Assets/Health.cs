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




    public void TakeDamage( int dmg)
    {
        hitPoints -= dmg;


        if (hitPoints <= 0)
        {
            CirclieSpawn.onEnemyDestroy.Invoke();
Destroy(gameObject);
        }
    }


}
