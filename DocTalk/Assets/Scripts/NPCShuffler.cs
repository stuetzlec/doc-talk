using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShuffler : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    void Start()
    {
        // Generate a random number (0 or 3)
        int randomIndex = Random.Range(0, 3);

        // Enable one object and disable the other based on the random number
        if (randomIndex == 0)
        {
            object1.SetActive(true);
            object2.SetActive(false);
            object3.SetActive(false);
        }
        else if (randomIndex == 1)
        {
            object1.SetActive(false);
            object2.SetActive(true);
            object3.SetActive(false);
        }
        else
        {
            object1.SetActive(false);
            object2.SetActive(false);
            object3.SetActive(true);
        }
    }

}
