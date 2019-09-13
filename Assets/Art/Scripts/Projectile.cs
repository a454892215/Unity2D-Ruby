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



    public void Launch(Vector2 direction, float force)
    {
        m_rigidbody2d.AddForce(direction * force);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("enemy"))
        {
            GameObject.Destroy(collision.gameObject);
        }
    }
}
