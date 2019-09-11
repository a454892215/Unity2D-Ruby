using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContr : MonoBehaviour
{
    Rigidbody2D m_rigidbody2D;
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
         m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = m_rigidbody2D.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        m_rigidbody2D.MovePosition(position);
    }
}
