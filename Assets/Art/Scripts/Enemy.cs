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
    private Animator animator;
    public ParticleSystem particleSystem;
    void Start()
    {
        originV3 = transform.position;
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private float movedTime = 500f;

    private bool broken = true;
    private
    void Update()
    {

        if (!broken)
        {
            return;
        }

        if (movedTime < changeDirTime)
        {
            movedTime += Time.deltaTime;
            Vector2 position = m_rigidbody2D.position;
            if (isHorizontal)
            {
                position.x = position.x + Time.deltaTime * speed;
                animator.SetFloat("moveX", speed);
                animator.SetFloat("moveY", 0);

            }
            else
            {
                position.y = position.y + Time.deltaTime * speed;
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", speed);
            }
            m_rigidbody2D.MovePosition(position);
        }
        else
        {
            movedTime = 0;
            speed = -speed;
        }
    }

    public void Fix()
    {
        broken = false;
        m_rigidbody2D.simulated = false;
        animator.Play("Idle");
        particleSystem.Stop();
    }
}
