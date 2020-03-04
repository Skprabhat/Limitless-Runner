using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
   public PlatformGenerator pg;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Platforms"))
        {
            collision.gameObject.SetActive(false);
            //pg.backtolist(collision.gameObject);
        }
        if(collision.CompareTag("Cloud"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
        }
    }
}
