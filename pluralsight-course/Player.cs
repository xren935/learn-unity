using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CapsuleCollider playerCollider; 
    public float moveSpeed = 5f; 
    // a var that stores the enemy object 
    private GameObject enemy; 
    private Enemy enemyScript; 

    // Start is called before the first frame update
    void Start(){
        playerCollider = this.GetComponent<CapsuleCollider>();
        playerCollider.height = 1f; 
        playerCollider.center = new Vector3(0f, 0.5f, 0f);
        
        enemy = GameObject.Find("Battle_Dummy");
    // find the component that's on the enemy obj 
    // now we've found the script that's on the enemy obj itself
        enemyScript = enemy.GetComponent<Enemy>(); 
    }

    // Update is called once per frame
    void Update(){
        // take user input 
        // use user input to move the character
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        // move the player character
        transform.Translate(movement * Time.deltaTime * moveSpeed);
        // take user input(space bar pressed)
        if(Input.GetKeyDown(KeyCode.Space)){
            enemyScript.enemyHealth--; 
        }
    }
}
