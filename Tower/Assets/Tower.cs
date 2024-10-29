using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[Serializable]
public class Tower 
{
  public string Name;
    public int cost;
    public GameObject prefab;



    public Tower(string _name, int _cost, GameObject _prefab)
    {
        Name = _name;
       
        cost = _cost;
        prefab = _prefab;
    }



}
