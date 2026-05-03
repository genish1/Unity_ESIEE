using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float arenaRadius = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(enemyPrefab, GetSpawnPosition(), Quaternion.identity);
    }

    Vector3 GetSpawnPosition()
    {
        float randomNumber;
        float randomX, randomZ;

        do
        {
            randomNumber = UnityEngine.Random.Range(-10f, 10f);
            randomX = randomNumber;

            randomNumber = UnityEngine.Random.Range(-10f, 10f);
            randomZ = randomNumber;
        }
        while (randomX * randomX + randomZ * randomZ > arenaRadius * arenaRadius);


        float spawnY = GameObject.Find("Player").transform.position.y;

        return new Vector3(randomX, spawnY, randomZ);
    }
}
