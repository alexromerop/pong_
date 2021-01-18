using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallControler : MonoBehaviour
{
    public GameObject player1points;
    public GameObject player2points;
    



    public float baseSpeed = 0.4f;
    public float margin = 0.3f;
    private float currentSpeedH = 0.0f;
    private float currentSpeedV = 0.0f;

    private int score_player1= 0;
    private int score_player2= 0;



    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        float rand = Random.Range(0.0f, 1.0f);
        if (rand < 0.5)
        {
            currentSpeedH = -baseSpeed;
        }
        else
        {
            currentSpeedH = baseSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() //fisica unity
    {
        float delta = Time.fixedDeltaTime * 1000;
        rigidBody.velocity = new Vector2(currentSpeedH, currentSpeedV) * delta;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            
            currentSpeedH = -1 * currentSpeedH;
            float ballY = transform.position.y;
            float paddleY = collision.collider.bounds.center.y;
            float paddleH = collision.collider.bounds.size.y;
            if (ballY < paddleH)
            {
                currentSpeedH--;
            }else if (ballY > paddleH)
            {
                currentSpeedH++;
            }
            if (ballY < paddleY - (paddleH / 2) * margin)
            {
                currentSpeedV = -baseSpeed;
                

            }
            else if (ballY > paddleY + (paddleH / 2) * margin)
            {
                currentSpeedV = baseSpeed;
          

            }
            else
            {
                currentSpeedV = 0;
            }
        }
        else if (collision.gameObject.tag == "Wall")
        {
            currentSpeedV = -1 * currentSpeedV;
            
        }
        else if (collision.gameObject.tag == "meta")
        {
            currentSpeedH = -1 * currentSpeedH;
            transform.position = new Vector3(0, 0, 0);
            float metax = collision.transform.position.x;
            if (metax< 0)
            {
                score_player2++;
                player2points.GetComponent<Text>().text = score_player2.ToString();

            }
            else
            {
                score_player1++;
                player1points.GetComponent<Text>().text = score_player1.ToString();
            }
        }

    
    }
}


