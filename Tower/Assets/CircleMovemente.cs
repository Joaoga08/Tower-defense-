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

    }
}
