using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioManager Instance { get; private set; }

    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip DoorOpeningSound;
    [SerializeField] AudioClip DoorClosingSound;
    [SerializeField] AudioClip JumpScareSound;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EventManager.Instance.OnDoorOpen += DoorOpeningSoundPlay;
        EventManager.Instance.OnDoorClose += DoorClosingSoundPlay;
        EventManager.Instance.OnFirstJumpScare += JumpScareSoundPlay;
    }

    private void DoorOpeningSoundPlay(int id)
    {
        audioSource.clip = DoorOpeningSound;
        audioSource.Play();
       
    }

    private void DoorClosingSoundPlay(int id)
    {
        audioSource.clip = DoorClosingSound;
        audioSource.Play();

    }

    private void JumpScareSoundPlay()
    {
        audioSource.clip = JumpScareSound;
        audioSource.Play();

    }

}
