using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Torreta : MonoBehaviour ,Iatacavel 
{
    
    [Header("References")]
    [SerializeField] private Transform TorreRotacaoPonto;
    [Header("Atributos")]
    [SerializeField] private float DanoTorreta = 5f;

    [SerializeField] private float RotacaoSpeed = 5f;

    [SerializeField] private LayerMask enemyMask;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private Transform firingPoint;

    [SerializeField] private float bps = 1f; // bala por segundo 

    private Transform target;
    private float timeUntilFire;


    public void Atacar(int dano)
    {
        if (target != null)
        {
            target = transform;
            
        }


      
       
    }
   
    private void Update()
    {
        if (target == null)
        {
            findTarget();

            return;
        }
        RotateTowardsTarget();


      if (!CheckTargetIsRange())
        {
            target = null;
        }

      else
        {
            timeUntilFire += Time.deltaTime;
            if (timeUntilFire >= 1f / bps) {
                Shoot();
            timeUntilFire = 0f;
            }


        }

    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        bullet bulletScript = bulletObj.GetComponent<bullet>();
        bulletScript.SetTarget(target);
    }
   

    private void findTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, DanoTorreta, (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {
target = hits[0].transform;
        }
    }

    private bool CheckTargetIsRange()
    {
       return Vector2.Distance(target.position,transform.position) <= DanoTorreta;
    }

    private void RotateTowardsTarget()
    {

        float angle = Mathf.Atan2(target.position.y - transform.position.y,target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion TorreRotacao = Quaternion.Euler(new Vector3(0f,0f,angle));

        TorreRotacaoPonto.rotation = Quaternion.RotateTowards (TorreRotacaoPonto.rotation,TorreRotacao,RotacaoSpeed * Time.deltaTime);


    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, DanoTorreta);
    }

   
   
}
