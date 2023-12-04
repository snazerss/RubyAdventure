using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slime : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip deathSound;
    public GameObject ruby;
    
    Rigidbody2D rigidbody2D;
    public int Hurt;
    public bool PrevHurt;
    
    Animator animator;
    // this line of code creates a variable called "rubyController" to store information about the RubyController script!
    private RubyController rubyController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject rubyControllerObject = GameObject.FindWithTag("RubyController"); //this line of code finds the RubyController script by looking for a "RubyController" tag on Ruby

        if (rubyControllerObject != null)

        {

            rubyController = rubyControllerObject.GetComponent<RubyController>(); //and this line of code finds the rubyController and then stores it in a variable

            print ("Found the RubyController Script!");

        }

        if (rubyController == null)

        {

            print ("Cannot find GameController Script!");

        }
        audioSource = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }
    
    void FixedUpdate()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController >();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
    
    //Public because we want to call it from elsewhere like the projectile script
    public void Fix()
    {
        
        Hurt = animator.GetInteger("Hurt"); 
        Hurt++;
        PrevHurt = animator.GetBool("PrevHurt");
        animator.SetInteger("Hurt", Hurt);
        if(PrevHurt == false)
            StartCoroutine(HurtRoutine());
        PrevHurt = animator.GetBool("PrevHurt");

        if(PrevHurt == true)
        {
            StartCoroutine(WaitRoutine());
        }
    }

    IEnumerator HurtRoutine()
    {
       // Debug.Log("Hurt Routine First test");
        PlaySound(hitSound);
        yield return new WaitForSeconds(1.0f);
        animator.SetTrigger("PrevHurt");
       // Debug.Log("Hurt Routine Second test");
        
    }

     IEnumerator WaitRoutine()
    {
        PlaySound(deathSound);
        //Debug.Log("Wait Routine First test");
        yield return new WaitForSeconds(2.0f);
        //Debug.Log("Wait Routine Second test");
        rigidbody2D.simulated = false;
        Destroy(gameObject);
        
        
    }

       public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}

