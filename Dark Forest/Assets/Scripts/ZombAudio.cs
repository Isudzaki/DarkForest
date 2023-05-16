using System.Collections;
using UnityEngine;

public class ZombAudio : MonoBehaviour
{
    public float timeToWhait = 3f;
    public AudioClip[] audio;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(spawnAudio());
    }

    IEnumerator spawnAudio()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeToWhait);
            AudioClip nowAudio = audio[Random.Range(0, audio.Length)];
            audioSource.clip = nowAudio;
            audioSource.Play();
        }
    }
}
