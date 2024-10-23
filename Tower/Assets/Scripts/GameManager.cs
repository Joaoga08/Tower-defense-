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


    // Start is called before the first frame update
    void Start()
    {
        currency = 100;
    }

  public void IncreaseCurrency(int amount)
    {
        currency += amount; 
    }

    public bool SpendCurrency(int amount) {
    if (amount <= currency)
        {
currency -= amount;
            return true;
        }

    else
        {
            Debug.Log("voce nao tem dinheiro suficiente para comprar esse item");
            return false;
        }
    }


}
