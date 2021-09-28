using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Player player;

    private AudioSource audioSource;

    private void Awake()
    {
        player = GetComponent<Player>();

        audioSource = GetComponent<AudioSource>();
    }

    public void ThrowKunai(GameObject kunai)
    {
        var projectile = Instantiate(kunai, player.transform.position + Vector3.up + player.transform.forward, player.transform.rotation).GetComponent<IProjectile>();

        projectile.CreateProjectile(player, player.transform.forward);
    }

    public void ThrowSFX(AudioClip castAttack)
    {
        audioSource.PlayOneShot(castAttack);
    }
    
}
