using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public int Damage =1;
    [SerializeField] public float Speed;
    PlayerMovementSide player; 

    public GameObject effect;

    public void Start(){
        player = GameObject.FindObjectOfType<PlayerMovementSide>();

    }

    public void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }   
   void OnTriggerEnter2D(Collider2D other)
   {
        if (other.CompareTag("Player")){
            //Take Damage
            Instantiate(effect, transform.position, Quaternion.identity);
            player.Health -= Damage;
            Debug.Log("Player got hit");
            Destroy(gameObject);
        }
        
   }
}
