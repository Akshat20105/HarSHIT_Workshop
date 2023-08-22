using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerlife : MonoBehaviour
{
    private Animator anime;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anime=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Traps")){
            Die();
        }
    }
    private void Die(){
            
            rb.bodyType=RigidbodyType2D.Static;
            anime.SetTrigger("death");
    }
    private void Restartlevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}

