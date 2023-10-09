using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;


    public float runSpeed = 40f;

    public Animator animator;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
    public bool GameStarted = false;
    public int score = 0;
    public int JumpCount = 0;
    public int highscore;
    [SerializeField] public AudioSource CherrySoundFX;

    void Start()
	{
		highscore = 0;
    }
	
	// Update is called once per frame
	void Update () {
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
            Debug.Log("Step1");
            animator.SetBool("Jump", true);
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "JumpBase")
		{
            controller.StartJump();
            //jump = true;//
            animator.SetBool("Jump", true);
            GameStarted = true;
			score += 20;
            JumpCount += 1;
            CherrySoundFX.Play();

            Destroy(col.gameObject, .05f);
		}
		else
		{
			jump = false;
        }

		if (GameStarted && col.collider.tag == "Ground")
        {
            //gameManager.EndGame();
            FindObjectOfType<GameManagement>().EndGame();
			GameStarted = false;
            if (score > highscore) { highscore = score; }
        }

        if (col.collider.tag == "Enemy")
        {
            //gameManager.EndGame();
            FindObjectOfType<GameManagement>().EndGame();
            GameStarted = false;
            if (score > highscore) { highscore = score; }
        }
    }

    void FixedUpdate ()
	{
        // Move our character
        //Debug.Log("Step2");
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
    }
	
	public void StopJumping()
	{
        animator.SetBool("Jump",false);
    }
}
