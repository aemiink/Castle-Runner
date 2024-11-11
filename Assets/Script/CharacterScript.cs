using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterScript : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float shift;  
    [SerializeField] float jumpForce;  
    [SerializeField] Animator anim;  
    public bool isGameOver;
    [SerializeField] GameObject menu;
    [SerializeField] TMP_Text score;
    public TMP_Text gems, gems2;
    public float roundScore;
    public int gemsNum;
    float gamePoint = 0f;
    float goldPoints = 5f;
    float redPoints = 7f;
    float bluePoints = 10f;
    bool isShiled;

    [SerializeField] TMP_Text gamePointBox;

    void Start()
    {              
    }     
    void Update() 
    {     
        if (!isGameOver)
        {
            roundScore += Time.deltaTime;
            score.text = "Score: " + roundScore.ToString("f1");

            if(Input.GetKeyDown(KeyCode.A) && transform.position.x > -shift)
            {
                transform.Translate(-shift, 0, 0);
            }
            if(Input.GetKeyDown(KeyCode.D) && transform.position.x < shift)
            {
                transform.Translate(shift, 0, 0);
            }

            if(Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);  
                                
            }
            if(rb.velocity.y > 0)   
            {
                anim.SetBool("jump", true);  
            }
            if(rb.velocity.y == 0)
            {
                anim.SetBool("jump", false); 
            }
        }
        else
        {
            EndGameCalculate();
            gems2.text =  gemsNum.ToString(); 

        }              
    }
    void FixedUpdate()
    {
        if (!isGameOver)
        {
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);       
        }
    }   

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if(isShiled)
            {
                Destroy(other.gameObject);
            }
            else
            {
                isGameOver = true;
                menu.SetActive(true);
                anim.SetBool("death", true);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("redGems"))
        {
            roundScore += redPoints;
            gemsNum += 2;           
            score.text = "Score: " + roundScore.ToString("f1"); 
            gems.text = "" + gemsNum.ToString();  
            Destroy(other.gameObject);  
        }
        else if (other.CompareTag("goldGems"))
        {
            roundScore += goldPoints;
            gemsNum += 1;  
            score.text = "Score: " + roundScore.ToString("f1");
            gems.text = "" + gemsNum.ToString();    
            Destroy(other.gameObject);       
        }
        else if (other.CompareTag("blueGems"))
        {
            roundScore += bluePoints;
            gemsNum += 3;
            score.text = "Score: " + roundScore.ToString("f1");
            gems.text = "" + gemsNum.ToString();    
            Destroy(other.gameObject);       
        }
        
        if (other.CompareTag("Shield"))
        {
            isShiled = true;
            Destroy(other.gameObject);
        }
    }
    void DeactiveShield()
    {
        isShiled = false;
    }

    void EndGameCalculate()
    {
        gamePoint = gemsNum * 0.5f + roundScore;
        gamePointBox.text = gamePoint.ToString("f1");

    }
}
