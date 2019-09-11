using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float changeDirTime = 2;
    public float speed = 500f;
    public bool isHorizontal = true;
    private Vector3 originV3;
    Rigidbody2D m_rigidbody2D;
    void Start()
    {
        originV3 = transform.position;
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private float movedTime = 500f;
    private
    void Update()
    {
        if (movedTime < changeDirTime)
        {
            movedTime += Time.deltaTime;
            Vector2 position = m_rigidbody2D.position;
            if (isHorizontal)
            {
                position.x = position.x + Time.deltaTime * speed;

            }
            else
            {
                position.y = position.y + Time.deltaTime * speed;
            }
            m_rigidbody2D.MovePosition(position);
        }
        else
        {
            movedTime = 0;
            speed = -speed;
        }


    }
}
