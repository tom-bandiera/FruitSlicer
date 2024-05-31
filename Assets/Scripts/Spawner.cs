using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Spawner: MonoBehaviour
{
    [SerializeField] private GameObject[] m_fruitsCollections;
    private SpawnPositions m_spawnPositions;
    [SerializeField] private GameObject m_container;

    private float m_minSpawnDelay = 0.25f;
    private float m_maxSpawnDelay = 1f;

    private float m_minAngle = -15f;
    private float m_maxAngle = 15f;

    private float m_minForce = 12;
    private float m_maxForce = 16;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnPositions = GetComponentInChildren<SpawnPositions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawningFruits () 
    {
        // Invoke("SpawnFruit", _spawnDelay);
        StartCoroutine(SpawnFruit());
    }

    public void StopSpawningFruits()
    {
        // CancelInvoke("SpawnFruit");
        StopCoroutine(SpawnFruit());
    }

    private IEnumerator SpawnFruit()
    {
        yield return new WaitForSeconds(2f);

        while (enabled)
        {
            int randomFruitIndex = Random.Range(0, m_fruitsCollections.Length);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(m_minAngle, m_maxAngle));
            GameObject fruit = Instantiate(m_fruitsCollections[randomFruitIndex], m_spawnPositions.GetRandomSpawnPosition().position, rotation, m_container.transform);
            Destroy(fruit, 5f);

            float force = Random.Range(m_minForce, m_maxForce);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);
            fruit.GetComponent<Rigidbody>().AddTorque(
                    new Vector3(
                        Random.Range(-45, 45),
                        0,
                        Random.Range(-45, 45)
                        )
                );

            yield return new WaitForSeconds(Random.Range(m_minSpawnDelay, m_maxSpawnDelay));
        }
    }

    public void SpawnBomb()
    {

    }
}
