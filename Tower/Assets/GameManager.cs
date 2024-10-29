using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public Transform startPoint;
    public Transform[] Path;
    public int currency;




    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
         currency = 150;
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }


    public bool SpendCurrency(int amount)
    {
        if (amount < currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("Não tem dinheiro");
            return false;
        }

    }

}
