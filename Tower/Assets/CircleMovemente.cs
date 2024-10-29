 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovemente : MonoBehaviour
{

    [Header("Referencias")]
    [Header("Atributos")]

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float MoveSpeed = 2f;
    private Transform target;

    private int PathIndex = 0;



    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
        baseSpeed = MoveSpeed;
>>>>>>> parent of f063590 (Merge branch 'main' into BuildManager)
=======

>>>>>>> parent of e0c0e7d (toore)
=======
>>>>>>> parent of b3dc0b3 (tower)
      target =  GameManager.Instance.Path[PathIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(target.position,transform.position) <= 0.1f)
        {
            PathIndex++;
            if(PathIndex == GameManager.Instance.Path.Length)
            {

                Destroy(gameObject);
                return;
            }
            else
            {

                target = GameManager.Instance.Path[PathIndex];
            }
        }
    }


    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * MoveSpeed;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
    }
    public void UpdateSpeed(float newSpeed)
    {
        MoveSpeed = newSpeed;
    }
    public void ResetSpeed()
    {
MoveSpeed = baseSpeed;
>>>>>>> parent of f063590 (Merge branch 'main' into BuildManager)
=======

>>>>>>> parent of e0c0e7d (toore)
=======
>>>>>>> parent of b3dc0b3 (tower)
    }
}
