using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

<<<<<<< HEAD

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
=======
[Serializable]
public class Tower 
{
    public string name;
    public int cost;
    public GameObject prefab;

    public Tower(string _name, int _cost, GameObject _prefab)
    {

        name = _name;

        cost = _cost;   
        prefab = _prefab;
    }


>>>>>>> parent of e723f55 (Merge branch 'main' into Movimentação)
}
