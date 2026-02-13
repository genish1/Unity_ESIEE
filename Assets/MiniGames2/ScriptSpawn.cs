using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject[] alienPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float startDelay = 2;
        float spawnInterval = 3;
        InvokeRepeating("RandomSpawn", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomSpawn()
    {
        int r = Random.Range(0, 3);
        Vector3 V = alienPrefabs[r].transform.position;
        V.x = Random.Range(-5, 5);
        Instantiate(alienPrefabs[r], V, alienPrefabs[r].transform.rotation);
    }
}
