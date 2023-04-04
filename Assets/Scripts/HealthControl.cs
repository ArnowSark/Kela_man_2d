using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthControl : MonoBehaviour
{
    
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public AudioSource restartSound;




    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0){
            restartSound.Play();
            RestartLevel();
        }
            
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Trap")){
            TakeDamage(20);
        }
        
    }

    void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void RestartLevel(){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);}
    
}
