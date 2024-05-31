using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositions : MonoBehaviour
{
    public GameObject[] m_spawnPositionsCollection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetRandomSpawnPosition()
    {
        return m_spawnPositionsCollection[Random.Range(0, m_spawnPositionsCollection.Length)].transform;
    }
}
