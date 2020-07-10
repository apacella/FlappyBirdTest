using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)//check if bird component is attached to what passed columns
        {
            GameControl.instance.BirdScored();
        }
    }
}
