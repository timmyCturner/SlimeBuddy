using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float swingSpeed;
    public float groundDrag;
    public int MaxDist = 10;
    public int MinDist = 5;

    [Header("Animation")]

    private Animation animBody;
    private Animation animOutline;

    public GameObject avatar;
    public GameObject avatarOutline;
    //private bool PreWalk;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    private Transform Player;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;
    public enum MovementState
    {
        freeze,
        attack,
        grappling,
        swinging,
        walking,
        sprinting,
        crouching,
        air
    }

    public bool freeze;

    public bool activeGrapple;
    public bool swinging;

    private void Start()
    {
        Player =  GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
        //PreWalk = false;
        startYScale = transform.localScale.y;
        animBody = avatar.GetComponent<Animation>();
        animOutline = avatarOutline.GetComponent<Animation>();
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();
        StateHandler();

        // handle drag
        if (grounded && !activeGrapple)
        {
          rb.drag = groundDrag;
          //Debug.Log(rb.velocity);
        }
        else
            rb.drag = 0;

        //TextStuff();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = 0;//Input.GetAxisRaw("Horizontal");
        verticalInput = 0;//Input.GetAxisRaw("Vertical");

        // when to jump
        if ( readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        // start crouch
        // if (Input.GetKeyDown(crouchKey))
        // {
        //     transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
        //     rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        // }
        //
        // // stop crouch
        // if (Input.GetKeyUp(crouchKey))
        // {
        //     transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        // }
    }

    private void StateHandler()
    {
        // Mode - Freeze
        if (freeze)
        {
            state = MovementState.freeze;
            moveSpeed = 0;
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }

        // Mode - Grappling
        else if (activeGrapple)
        {
            state = MovementState.grappling;
            moveSpeed = sprintSpeed;
        }

        // Mode - Swinging
        else if (swinging)
        {
            state = MovementState.swinging;
            moveSpeed = swingSpeed;
        }

        // Mode - Crouching
        // else if (Input.GetKey(crouchKey))
        // {
        //     state = MovementState.crouching;
        //     moveSpeed = crouchSpeed;
        // }

        // Mode - Sprinting
        // else if (grounded && Input.GetKey(sprintKey))
        // {
        //     state = MovementState.sprinting;
        //     moveSpeed = sprintSpeed;
        //     animArm = arm.GetComponent<Animation>();
        //     animBody = avatar.GetComponent<Animation>();
        //     animOutline = avatarOutline.GetComponent<Animation>();
        //
        //     if (rb.velocity != Vector3.zero){
        //       animBody.Play("LegsRun");
        //       animOutline.Play("LegsRunOutline");
        //     }
        //     if (Input.GetMouseButtonDown(0)){
        //         animArm.Play("SwingDown");
        //         //Debug.Log("armDeleage");
        //     }
        //     else if (rb.velocity != Vector3.zero){
        //       if(!animArm.isPlaying)
        //         animArm.Play("Walk");
        //
        //     }
        // }

        // Mode - Walking
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            ChasePlayer();
            if (rb.velocity != Vector3.zero){
              animBody.Play("LegsWalk");
              animOutline.Play("LegsWalkOutline");
            }
          }

        // Mode - Air
        else
        {
            state = MovementState.air;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
    // private void armDeleage(){
    //
    //   //AnimationState armState = arm.GetComponent<AnimationState>();
    //
    //   if (Input.GetMouseButtonDown(0)){
    //       animArm.Play("SwingDown");
    //       //Debug.Log("armDeleage");
    //   }
    //   else if (rb.velocity != Vector3.zero){
    //     if(!animArm.isPlaying)
    //       animArm.Play("Walk");
    //
    //   }
    //   //Debug.Log(armState.name);
    // }
    // private void SwordAttack(){
    //   //CanAttack = false;
    //   animArm = arm.GetComponent<Animation>();
    //   animArm.Play("SwingDown");
    //   // Animator anim = CurrentWeapon.GetComponent<Animator>();
    //   //anim.SetTrigger("Attack");
    //   //StartCoroutine(ResetAttackCooldown());
    // }
    // private void PreWalkFun(){
    //   PreWalk = true;
    // }
    public void ChasePlayer(){

      transform.LookAt(Player);

         if (Vector3.Distance(transform.position, Player.position) >= MinDist)
         {

             transform.position += transform.forward * moveSpeed * Time.deltaTime;



             if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
             {
                 //Here Call any function U want Like Shoot at here or something
             }

         }
     }

    private void MovePlayer()
    {
        if (activeGrapple) return;
        if (swinging) return;

        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on slope
        if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        // on ground
        else if (grounded){
          //rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }


        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        // turn gravity off while on slope
        rb.useGravity = !OnSlope();
    }

    private void SpeedControl()
    {
        if (activeGrapple) return;

        // limiting speed on slope
        if (OnSlope() && !exitingSlope)
        {
            if (rb.velocity.magnitude > moveSpeed)
                rb.velocity = rb.velocity.normalized * moveSpeed;
        }

        // limiting speed on ground or in air
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            // limit velocity if needed
            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
    }

    private void Jump()
    {
        exitingSlope = true;

        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;

        exitingSlope = false;
    }

    private bool enableMovementOnNextTouch;
    public void JumpToPosition(Vector3 targetPosition, float trajectoryHeight)
    {
        activeGrapple = true;

        velocityToSet = CalculateJumpVelocity(transform.position, targetPosition, trajectoryHeight);
        Invoke(nameof(SetVelocity), 0.1f);

        Invoke(nameof(ResetRestrictions), 3f);
    }

    private Vector3 velocityToSet;
    private void SetVelocity()
    {
        enableMovementOnNextTouch = true;
        rb.velocity = velocityToSet;

        //cam.DoFov(grappleFov);
    }

    public void ResetRestrictions()
    {
        activeGrapple = false;
        //cam.DoFov(85f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (enableMovementOnNextTouch)
        {
            enableMovementOnNextTouch = false;
            ResetRestrictions();

            GetComponent<Grappling>().StopGrapple();
        }
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    public Vector3 CalculateJumpVelocity(Vector3 startPoint, Vector3 endPoint, float trajectoryHeight)
    {
        float gravity = Physics.gravity.y;
        float displacementY = endPoint.y - startPoint.y;
        Vector3 displacementXZ = new Vector3(endPoint.x - startPoint.x, 0f, endPoint.z - startPoint.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * trajectoryHeight);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * trajectoryHeight / gravity)
            + Mathf.Sqrt(2 * (displacementY - trajectoryHeight) / gravity));

        return velocityXZ + velocityY;
    }


}
