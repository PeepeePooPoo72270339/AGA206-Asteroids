using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Playsound()
    {
        if (audioClip == null || audioClip.Length == 0)
            return;
        audioSource.clip = audioClip[0];
        audioSource.Play();
    }

    public void PlayRandomSound(bool randomPitch = true)
    {
        if (audioClip == null || audioClip.Length == 0)
            return;
        audioSource.clip = audioClip[Random.Range(0, audioClip.Length)];
        if(randomPitch == true)
        {
            audioSource.pitch = Random.Range(-0.9f, 1.1f);
            audioSource.Play();
        }
        else
        {
            audioSource.Play();

        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
