using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip collectedClip;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            GameObject.Destroy(gameObject);
            PlayerContr controller = collision.GetComponent<PlayerContr>();
            if (controller != null)
            {
                GameSound.instance.PlaySound(collectedClip);
                controller.ChangeHealth(1);
            }
          
        }
     
    }
}
