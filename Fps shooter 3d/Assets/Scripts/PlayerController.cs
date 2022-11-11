using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    //States
    public bool isGameActive;

    #region Move variables
    //Player move variables
    private Rigidbody rb;
    [SerializeField] private float walkSpeed = 300f;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    public bool isReadyToMove;
    public bool isMoving;
    #endregion

    #region Layer mask variables
    //Layer mask variables
    public bool isGrounded;
    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask whatIsGround;
    #endregion

    #region Gravity variables
    //Gravity variables
    private float gravity = /*-40f*/-8000f;
    private Vector3 velocity;
    #endregion

    #region Jump variables
    //Jump variables
    private float jumpHeight = 5f;
    public bool isReadyToJump;
    private KeyCode jumpKey = KeyCode.Space;
    #endregion

    #region Sprint variables
    //Sprint variables
    private KeyCode sprintKey = KeyCode.LeftShift;
    private float sprintSpeed = 500f;
    public bool isReadyToSprint;
    #endregion

    #region Crouch variables
    //Crouch variables
    private float crouchSpeed = 125f;
    public bool isCrouching;
    private KeyCode crouchKey = KeyCode.C;
    private Vector3 crouchScale = new Vector3(0f, 0.5f, 0f);
    #endregion

    #region Sound varables
    //Sound variables
    [SerializeField] private AudioSource walkSound;
    [SerializeField] private AudioSource jumpSound;
    #endregion

    //ceiling detection
    private RaycastHit ceilingRayHit;
    public bool ceilingDetected;
    public Transform ceilingPosition;
    private float ceilingCheckDistance = 1f;

    private InteractionUI IN_UI;
    private PIckAndDrop pickandDropScriptRef;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Script refrences
        IN_UI = GameObject.FindGameObjectWithTag("Weapon_Trigger").GetComponent<InteractionUI>();
        pickandDropScriptRef = GameObject.FindGameObjectWithTag("Weapon").GetComponent<PIckAndDrop>();

        //isReadyToMove = true;
        isReadyToSprint = true;
    }

    private void Update()
    {
        //Function calls
        if (isGameActive)
        {
            isReadyToMove = true;
            if (isReadyToMove)
            {
                MovePlayer();
                Sprint();
            }
            Jump();
            Crouch();
        }

        //Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);
        if (isGrounded && velocity.y < 0)
        {
            rb.drag = 5f;
            velocity.y = 0f;
            isReadyToJump = true; 
        }
        else
        {
            rb.AddForce(0f, velocity.y * Time.deltaTime, 0f);
            isReadyToJump = false;
        }

        velocity.y += gravity * Time.deltaTime;

        //Debug.Log(transform.position.y);

        ceilingDetected = Physics.CheckSphere(ceilingPosition.position, ceilingCheckDistance, whatIsGround);

        if (ceilingDetected)
        {
            Debug.Log("Ceiling detected");
        }
    }

    //Player move function
    public void MovePlayer()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;

        rb.AddForce(moveDirection * walkSpeed * 10f * Time.deltaTime);

        //Check if player is moving and plays waling sound
        if(moveDirection.x != 0 || moveDirection.z != 0 && isGrounded)
        {
            isMoving = true;
            if (!walkSound.isPlaying) walkSound.Play();
        }
        else
        {
            isMoving = false;
            if (walkSound.isPlaying || !isGrounded) walkSound.Stop();
        }
    }

    //Player jump function
    private void Jump()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded && isReadyToJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -600/*-4*/ * gravity);
            Debug.Log("Jumping");

            //Audio play
            jumpSound.Play();
            walkSound.Stop();

            //Debug.Log(jumpHeight);
        }
    }

    //Player sprint function
    private void Sprint()
    { 
        if (Input.GetKeyDown(sprintKey) && isGrounded && isReadyToSprint && isReadyToMove)
        {
            walkSpeed = sprintSpeed;
            isReadyToSprint = false;
        }

        if (Input.GetKeyUp(sprintKey) && !isCrouching)
        {
            walkSpeed = 300f;
            isReadyToSprint = true;
        }
    }

    //Player crouch function
    private void Crouch()
    {
        if (Input.GetKeyDown(crouchKey) && isGrounded)
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchScale.y, transform.localScale.z);
            isCrouching = true;
            isReadyToSprint = false;
            walkSpeed = crouchSpeed;
            
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

        }
        if (Input.GetKeyUp(crouchKey) && isCrouching && !ceilingDetected)
        {
            transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
            isCrouching = false;
            isReadyToSprint = true;
            walkSpeed = 300f;
        }
    }
}
