using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class characterContoller : MonoBehaviour
{
    // Initializing our public / private variables
    public Rigidbody2D rb;
    public Animator animator;
    public float runSpeed = 3f;// public so it's changeable in the Editor
    public float jumpForce = 700f;
    private float horizontalMove;
    private bool gameHasEnded = false;

    private void QuitToMenu()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void Die()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            FindObjectOfType<AudioManager>().Play("GameOver");
            FindObjectOfType<AudioManager>().Stop("Theme");
            rb.bodyType = RigidbodyType2D.Static;
            animator.SetTrigger("Death");
            Invoke("QuitToMenu",2f);
            
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        horizontalMove = 1;// because we want to move right
    }
    void Update()
    {
        //Make the character to move with a fix speed
        animator.SetFloat("Speed", horizontalMove);
        transform.position += new Vector3(horizontalMove,0,0) * Time.deltaTime * runSpeed;

        //Testing if the character is grounded, if yes jump for touching the screen
        if(CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y <= 0.03)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

        // Controlling the jump animation
        if(rb.velocity.y == 0)
        {
            animator.SetBool("IsJumping",false);
        }
        else if(rb.velocity.y > 0)
        {
            animator.SetBool("IsJumping",true);
        }
    } 
    void FixedUpdate()
    {
        if(rb.position.y < -2f)
        {
            Die();
        }
    }
}
