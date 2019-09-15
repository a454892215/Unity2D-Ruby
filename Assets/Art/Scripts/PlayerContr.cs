using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContr : MonoBehaviour
{
    Rigidbody2D m_rigidbody2D;
    public float speed = 3.0f;
    Animator animator;
    private Vector2 currentPosition;
    public Vector2 lookDirection = new Vector2(1, 0);

    public GameObject projectilePrefab;

    private int maxHealth = 5;
    private int currentHealth = 5;

    private static AudioSource audioSource;

    public AudioClip hitPlayer;
    public AudioClip launchclip;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
    }

    internal void ChangeHealth(int value)
    {
        currentHealth += value;
        currentHealth = currentHealth > maxHealth ? maxHealth : currentHealth;
        updateHealthUI();
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
            lookDirection.Normalize(); //使X 或者Y为1
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        currentPosition = m_rigidbody2D.position;
        currentPosition = currentPosition + speed * move * Time.deltaTime;
        m_rigidbody2D.MovePosition(currentPosition);


        if (Input.GetKeyDown(KeyCode.F))
        {
            Launch();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(m_rigidbody2D.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NPC cpn = hit.collider.GetComponent<NPC>();
                if (cpn != null)
                {
                    cpn.DisplayDialog();
                }
            }
        }

    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, currentPosition + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 600);
        GameObject.Destroy(projectileObject, 2);
        animator.SetTrigger("Launch");
        PlaySound(launchclip);
    }


    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("enemy"))
        {
            PlaySound(hitPlayer);
            animator.SetTrigger("Hit");
            currentHealth--;
            updateHealthUI();
        }
    }

    private void updateHealthUI()
    {

        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        if (currentHealth <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

}
