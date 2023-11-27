using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //public bool once = true;
    public ParticleSystem collisionParticleSystem;
    public AudioClip collectedClip;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (other.CompareTag("RubyController"))
        {
            if (controller.health < controller.maxHealth)
            {
                var em = collisionParticleSystem.emission;
                //var dur = collisionParticleSystem.duration;

                em.enabled = true;
                collisionParticleSystem.Play();
                //once = false;

                controller.ChangeHealth(1);
                Destroy(gameObject);
            
                controller.PlaySound(collectedClip);
                
            }
        }

    }
}
