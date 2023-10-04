using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
