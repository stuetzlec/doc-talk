using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShuffler : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    void Start()
    {
        // Generate a random number (0 or 1)
        int randomIndex = Random.Range(0, 2);

        // Enable one object and disable the other based on the random number
        if (randomIndex == 0)
        {
            object1.SetActive(true);
            object2.SetActive(false);
        }
        else
        {
            object1.SetActive(false);
            object2.SetActive(true);
        }
    }

}
