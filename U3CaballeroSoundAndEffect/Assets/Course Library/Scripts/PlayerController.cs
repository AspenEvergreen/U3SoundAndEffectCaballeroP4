using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playRB;
    public float jumpForce;
    public float doubleJumpForce;
    public float playGrav;

    public int jumpAmt = 2;
    public int maxJumps = 2;

    public bool isOnGround = true;
    public bool gameOver = false;

    private Animator playerAnim;

    public ParticleSystem boom;
    public ParticleSystem dirt;

    public AudioClip jump;
    public AudioClip crash;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playRB = GetComponent<Rigidbody>();
        Physics.gravity *= playGrav;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // jumping
        // make int of jumps
        // jumps = 2
        // jump = -1
        // if int > 0 can jump
        // if onGround, jump = 2

        if (Input.GetKeyDown(KeyCode.Space) && jumpAmt > 0 && !gameOver)
        {
            if (jumpAmt == maxJumps)
            {
                playRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                
                isOnGround = false;
                playerAnim.SetTrigger("Jump_trig");
                playerAudio.PlayOneShot(jump, 1.0f);
            }
        else
            {
                playRB.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
               
                isOnGround = false;
                playerAnim.SetTrigger("DJump_trig");
                playerAudio.PlayOneShot(jump, 1.0f);
            }
            jumpAmt--;
            dirt.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
            dirt.Play();
            jumpAmt = 2;
        }
        else if(collision.gameObject.CompareTag("obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            boom.Play();
            dirt.Stop();
            playerAudio.PlayOneShot(crash, 1.0f);
        }
    }
}
