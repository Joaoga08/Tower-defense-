using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclieSpawn : MonoBehaviour
{

    [Header("Atributos")]
    [SerializeField] private GameObject [] spawnPrefab;
    [SerializeField] private int basebola = 8;
    [SerializeField] private float bolasPorSegundo = 0.5f;
    [SerializeField] private float tempoWaves;
    [SerializeField] private float difficultyScalingFactor = 0.75f;

    private int currentWave = 1;
    private float tempoDeSpawn;

    private int bolaviva;
    private int BolaesquerdaSpawn;
    private bool isSpawning = false;



    private void Start()
    {
        StartWave();
    }

    // Start is called before the first frame update
   
   

    // Update is called once per frame
    void Update()
    {

        if (!isSpawning) return;
        
            
        
        tempoDeSpawn += Time.deltaTime;
        if(tempoDeSpawn >=( 1f / bolasPorSegundo)&& BolaesquerdaSpawn > 0)
        {
            SpawnBola();
            BolaesquerdaSpawn--;
            bolaviva++;
            tempoDeSpawn = 0f;
        }
    }

    private void StartWave()
    {
        isSpawning = true;
        BolaesquerdaSpawn = BolasPorWave();
    }

    private void SpawnBola()
    {
        GameObject prefabToSpawn = spawnPrefab[0];

       Instantiate(prefabToSpawn, GameManager.Instance.startPoint.position, Quaternion.identity);
       
    }

    private int BolasPorWave()
    {
        return Mathf.RoundToInt(basebola * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}
