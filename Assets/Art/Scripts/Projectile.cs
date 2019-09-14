using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D m_rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Awake()
    {
        m_rigidbody2d = GetComponent<Rigidbody2D>(); //start 函数中拿不到？？
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void Launch(Vector2 direction, float force)
    {
        m_rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //we also add a debug log to know what the projectile touch
      
        if (other.gameObject.tag.Equals("enemy"))
        {
            GameObject.Destroy(other.gameObject);
        }
    }
    
}
