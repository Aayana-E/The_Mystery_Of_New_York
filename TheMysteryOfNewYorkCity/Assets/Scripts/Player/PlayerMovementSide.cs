using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerMovementSide : MonoBehaviour
{

    private Vector2 targetPos;
    public float YIncrement;

    [SerializeField] public float speed;
    [SerializeField] public float maxHeight;
    [SerializeField] public float minHeight;

    public int Health = 3;

    public GameObject effect;
    public TextMeshProUGUI  healthDisplay;

    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = Health.ToString();
        if (Health <= 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameOver.SetActive(true);
            Destroy(gameObject);

        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos,speed+Time.deltaTime);
        if ( (Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.W)) && transform.position.y < maxHeight ){
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x ,transform.position.y+YIncrement);
            //transform.position = targetPos;
        }else if ( (Input.GetKeyDown(KeyCode.DownArrow)) || (Input.GetKeyDown(KeyCode.S)) && transform.position.y > minHeight){
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x , transform.position.y - YIncrement);
            //transform.position = targetPos;
        
        }
        
    }
}
