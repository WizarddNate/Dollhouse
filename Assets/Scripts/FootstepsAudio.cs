using System.Collections;
using UnityEngine;

/// <summary>
/// Change footsteps audio depending on what surface the player is walking on
/// </summary>

public class FootstepsAudio : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Audio tracks")]
    public AudioClip floor1;
    public AudioClip floor2;
    public AudioClip grass1;
    public AudioClip grass2;

    [Header("Raycast")]
    public Transform rayStartPos;
    public float range;
    public LayerMask layerMask;
    RaycastHit hit;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// call using unity event while player is being animated
    /// </summary>
    public void PlayFootsteps()
    {
        //this hurts me. Please make into a switch statement
        if (Physics.Raycast(rayStartPos.position, rayStartPos.transform.up * -1, out hit, range, layerMask))
        {

            if (hit.collider.CompareTag("Floor"))
            {
                Play(floor1);
            }
            if (hit.collider.CompareTag("Grass"))
            {
                Play(grass1);
            }
            else
            {
                return;
            }
        }
    }

    private void Play(AudioClip audio)
    {
        audioSource.pitch = Random.Range(0.8f, 1f);
        audioSource.PlayOneShot(audio);
    }
}
