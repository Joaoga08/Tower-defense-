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

    private bool isDestroyed = false;


    public void TakeDamage( int dmg)
    {
        hitPoints -= dmg;


        if (hitPoints <= 0 && !isDestroyed)
        {
            CirclieSpawn.onEnemyDestroy.Invoke();

            isDestroyed = true;
Destroy(gameObject);
        }
    }


}
