using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : Singleton<DeathSound>
{
    [SerializeField] private AudioSource deathAudio;

    protected override void Awake()
    {
        base.Awake();
    }

    public void enemyDeathAudio()
    {
        deathAudio.Play();
    }
}
