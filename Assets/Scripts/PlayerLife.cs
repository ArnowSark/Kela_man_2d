using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLife : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private Vector3 respwanPoint;
    public float respawnDelay;
    public AudioSource respawnSound;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respwanPoint = transform.position;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProcessColission(collision.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        ProcessColission(other.gameObject);
    }

    private void Respawn(){
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;            
    }
    private void Re()
    {
        gameObject.SetActive (false);
        gameObject.transform.position = respwanPoint;
        gameObject.SetActive (true);
        anim.SetTrigger("appear");
        rb.bodyType = RigidbodyType2D.Dynamic;
        
    }

    

    void ProcessColission(GameObject other){
        if(other.gameObject.CompareTag("Trap")){
            Respawn();
            respawnSound.Play();
        }
            if(other.tag == "Checkpoint")
        {
            respwanPoint = transform.position;
        }
    }

    
}
