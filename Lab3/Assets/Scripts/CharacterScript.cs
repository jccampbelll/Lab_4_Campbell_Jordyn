using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;
    public float enemyHeight;
    public int maxJumps = 1;
    public int jumps;
    public int lives = 3;
    public float radius = 0.5f;
    public float coinCollect = 0;
    public GameObject Coin;
    public GameObject Downpoint;

    public List<GameObject> heartts = new List<GameObject>();

    public LayerMask rayCastLayer;
    public LayerMask powerMask;

    public Animator animIdle;
    public Animator animJump;
    public Animator animDeath;
    public Animator animPunch;
    public Animator animYay;

    private bool isGrounded;

    [SerializeField]
    private bool isGameOver;


	// Use this for initialization
	void Start ()
    {
        isGameOver = false;
        lives = 3;
        animDeath.SetBool("death", false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        animIdle.SetBool("movement", false);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            animIdle.SetBool("movement", true);
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
            //transform.localScale = new Vector3(-1, 1, 1);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animIdle.SetBool("movement", true);
            transform.position += Vector3.left * playerSpeed * Time.deltaTime;
            //transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (jumps < maxJumps)
            {
                animIdle.SetBool("movement", false);
                animJump.SetBool("jump", true);
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                jumps++;
            }
        }
       
        if (isGameOver == true)
        {
            transform.position = new Vector3(-10.02f, -2.76f, 0);
            Start();
        }

        Health();
	}



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 13)
        {
            isGrounded = true;
            jumps = 0;
            animJump.SetBool("jump", false);

        }
        if (collision.gameObject.layer == 15)
        {
            Destroy(Coin);
            coinCollect = 1;
        }

       if (collision.gameObject.layer == 4)
        {
            Death();
        }

        if (collision.gameObject.layer == 9)
        {
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, GetComponent<BoxCollider2D>().size , 0, Vector2.down, Mathf.Infinity, rayCastLayer);
            if (hit.collider != null && hit.collider.gameObject.layer == 9)
            {
                GameObject Enemy = collision.rigidbody.gameObject;
                KillEnemy(collision.rigidbody.gameObject);
            }
            else
            {
                lives--;
            }


        }

        if (collision.gameObject.layer == 11)
        {
          
            SpawnRandom(collision.rigidbody.gameObject);
        }

        if (collision.gameObject.layer == 14 && coinCollect == 1)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                animYay.SetBool("gameOver", true);
                transform.position = Downpoint.transform.position;
                GameOver();
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void Health()
    {
       
            if (lives == 3)
            {
            heartts[2].SetActive(true);
            }
            if (lives == 2)
            {
            heartts[2].SetActive(false);
            }
            if (lives == 1)
            {
            heartts[1].SetActive(false);
            }   
            if (lives == 0 )
            {
            heartts[0].SetActive(false);
            }
            if (lives == -1)
            {
            Death();
            }
    }
    
    
  public void KillEnemy(GameObject Enemy)
    {
        Enemy.GetComponent<EnemyScript>().EnemyDeath(Enemy);
    }

  public void SpawnRandom(GameObject Random)
    {
        Random.GetComponent<PowerBox>().SpawnPowerup();
    }

  public void Death()
    {
        int i;
        lives = 0;

      for (i = 0; i < 3; i++)
      {
         animIdle.SetBool("movement", false);
         animDeath.SetBool("death", true);  
      }
        transform.position = new Vector3(-10.02f, -2.76f, 0);
        Start();
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        isGameOver = true;
    }
    
}
