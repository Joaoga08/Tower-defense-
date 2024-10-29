using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [Header("Atributos")]
    [SerializeField] private GameObject [] spawnPrefab;
    [SerializeField] private int basebola = 8;
    [SerializeField] private float bolasPorSegundo = 0.5f;

    private int currentWave = 1;
    private float tempoDeSpawn;

    private int bolaviva;
    private int BolaesquerdaSpawn;
    private bool isSpawning = false;



    private void Start()
    {

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
