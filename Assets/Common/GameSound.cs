using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;

    public static GameSound instance { get; private set; }

    void Awake()
    {
        instance = this;
    }


    void Start()
    {
         audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}
