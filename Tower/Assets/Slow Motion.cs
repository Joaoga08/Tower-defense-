using System.Collections;

using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TurretSlomo : MonoBehaviour

{

  
    [SerializeField] protected LayerMask enemyMask;
    private float timeUntilFire;
    [SerializeField] private float aps = 4f;

    [SerializeField] private float FreezeTime = 1f;
    [SerializeField] private float TargetRange;
    // Start is called before the first frame update

    private void Update()

    {

        timeUntilFire += Time.deltaTime;

        if (timeUntilFire >= 1f / aps)

        {

            FreezeEnemies();

            timeUntilFire = 0f;

        }
    }
    private void FreezeEnemies()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position,TargetRange , (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {

            for (int i = 0; i < hits.Length; i++)

            {

                RaycastHit2D hit = hits[i];

                CircleMovemente em = hit.transform.GetComponent<CircleMovemente>();

                em.UpdateSpeed(0.5f);

                StartCoroutine(ResetEnemySpeed(em));

            }

        }

    }

    private IEnumerator ResetEnemySpeed(CircleMovemente em)

    {

        yield return new WaitForSeconds(FreezeTime);

        em.ResetSpeed();

    }

   

}


