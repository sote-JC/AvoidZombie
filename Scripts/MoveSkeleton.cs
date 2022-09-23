using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSkeleton : MonoBehaviour
{
    private float speed = 35.0f;
    private float time = 0.0f;
    private AudioSource skeletonAudio;
    public AudioClip brokenSound;
    // Start is called before the first frame update
    void Start()
    {
        skeletonAudio = GetComponent<AudioSource>();
        skeletonAudio.PlayOneShot(brokenSound, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 2.0f)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
