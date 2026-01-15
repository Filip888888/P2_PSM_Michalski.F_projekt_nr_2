using UnityEngine;

public class Sound : MonoBehaviour
{

    private AudioSource sound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
