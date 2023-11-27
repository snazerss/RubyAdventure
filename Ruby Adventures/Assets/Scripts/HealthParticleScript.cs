using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthParticleScript : MonoBehaviour
{
    public bool once = true;
    public ParticleSystem collisionParticleSystem;
    //public SpriteRenderer sr;

   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && once)
        {
                var em = collisionParticleSystem.emission;
                //var dur = collisionParticleSystem.duration;

                em.enabled = true;
                collisionParticleSystem.Play();
                once = false;
                //Destroy(sr);
                
        }
    }
}
