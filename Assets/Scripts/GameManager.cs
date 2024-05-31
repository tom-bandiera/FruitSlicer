using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Spawner m_spawner;

    // Start is called before the first frame update
    void Start()
    {
        m_spawner.StartSpawningFruits();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
