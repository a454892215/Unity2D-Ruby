using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContr : MonoBehaviour
{
    Rigidbody2D m_rigidbody2D;
    public float speed = 3.0f;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
       if (Input.GetKey("e"))
        {
            animator.SetTrigger("Launch");
        }


        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            print("=====================1===lookDirection:" + lookDirection);
            lookDirection.Normalize();
            print("=====================2===lookDirection:" + lookDirection);
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = m_rigidbody2D.position;
        position = position + speed * move * Time.deltaTime;
        // position.y = position.y + speed * vertical * Time.deltaTime;
        m_rigidbody2D.MovePosition(position);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("enemy"))
        {
            animator.SetTrigger("Hit");
        }
    }
}
