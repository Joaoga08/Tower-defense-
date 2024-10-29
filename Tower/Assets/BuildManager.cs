using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
=======
>>>>>>> parent of e723f55 (Merge branch 'main' into Movimentação)
    public static BuildManager instance;

    [Header("References")]
    
    [SerializeField] private Tower[] towers;

    private int SelectedTower = 0;

    private void Awake()
>>>>>>> Stashed changes
    {
        
    }

<<<<<<< Updated upstream
    // Update is called once per frame
    void Update()
    {
        
=======
    public Tower GetSelectedTower()
    {
        return towers[SelectedTower];
<<<<<<< HEAD
    }

    public void SetSelectedTower(int _selectedTower)
    {
SelectedTower = _selectedTower;
=======
>>>>>>> Stashed changes
>>>>>>> parent of e723f55 (Merge branch 'main' into Movimentação)
    }
}
