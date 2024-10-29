using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    

    [Header("References")]
    [SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] private Tower[] towers;


    private int SelectedTower = 0;

    private void Awake()
    {
        instance = this;
    }

    public Tower GetSelectedTower()
 
    {
        return towers[SelectedTower];
    }


    public void SetSelectedTower(int _selectedTower)
    {
SelectedTower = _selectedTower; 
    }
}
