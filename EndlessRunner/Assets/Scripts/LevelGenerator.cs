using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> levelPrefabs;
    [SerializeField]
    private Vector3 SpawnPoint;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private float distanceToSpawn = 5f;

    [SerializeField]
    private List<GameObject> spawnedLevels;

    [SerializeField]
    private int maxSpawnedLevels = 3;

    private void generateNewLevel() 
    {
        GameObject level = levelPrefabs[Random.Range(0, levelPrefabs.Count)];

        GameObject SpawnedObject = Instantiate(level, SpawnPoint, Quaternion.identity);

        spawnedLevels.Add(SpawnedObject);

        if (spawnedLevels.Count > maxSpawnedLevels) 
        {
            Destroy(spawnedLevels[0]);
            spawnedLevels.RemoveRange(0, 1);
        }

        SpawnPoint = SpawnedObject.transform.Find("EndPosition").transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = new Vector3(64.8f, -0.07f, 0f);
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, SpawnPoint) < distanceToSpawn)
        generateNewLevel();
    }
}
