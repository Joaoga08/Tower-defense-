using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
=======
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
>>>>>>> Stashed changes
    }
}
