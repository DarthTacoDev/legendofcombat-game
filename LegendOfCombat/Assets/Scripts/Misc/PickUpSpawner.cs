using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldCoin, healthGlobe, staminaGlobe;

    public void DropItems()
    {
        int randomNum = Random.Range(1, 5);
        int SpecificRandomNum = Random.Range(1, 4);
        if (randomNum == 1)
        {
            if (SpecificRandomNum == 2)
            {
                Instantiate(healthGlobe, transform.position, Quaternion.identity);
            }
        }

        if (randomNum == 2)
        {
            Instantiate(staminaGlobe, transform.position, Quaternion.identity);
        }

        if (randomNum == 3)
        {
            int RandomAmountOfGold = Random.Range(1, 4);
            for (int i = 0; i < RandomAmountOfGold; i++)
            {
                Instantiate(goldCoin, transform.position, Quaternion.identity);
            }
        }
    }
}
