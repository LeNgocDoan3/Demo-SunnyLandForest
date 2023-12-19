using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int carrot = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Carrot"))
        {
            Destroy(collision.gameObject);
            carrot++;
            Debug.Log("Carrot: " + carrot);
        }
    }
    
}
