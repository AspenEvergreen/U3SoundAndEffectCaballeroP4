using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playRB;
    public float jumpForce;
    public float playGrav;
    public bool isOnGround = true;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playRB = GetComponent<Rigidbody>();
        Physics.gravity *= playGrav;
          
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
        }
        else if(collision.gameObject.CompareTag("obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
        }
    }
}
