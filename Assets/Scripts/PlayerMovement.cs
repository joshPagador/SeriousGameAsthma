using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ManagersSingleton<PlayerMovement>
{

    [SerializeField] private string horizontalInput;
    [SerializeField] private string verticalInput;

    [SerializeField] private float slopeForce;
    [SerializeField] private float slopeRayLength;

    private CharacterController controller;
    private Rigidbody rb;

    //movement variables
    float movementSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float runBuildUp;
    [SerializeField] private KeyCode runKey;

    //jump variables
    [SerializeField] private AnimationCurve fallOff;
    [SerializeField] private float jumpingMultiplier;
    [SerializeField] private KeyCode jumpKey;
    private bool isJumping;
    [SerializeField] private AudioClip m_JumpSound;

    private AudioSource m_AudioSource;
    


    void Awake()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();
        
    }

    void Movement()
    {
        float horizInput = Input.GetAxis(horizontalInput);
        float vertInput = Input.GetAxis(verticalInput);

        Vector3 moveForward = transform.forward * vertInput;
        Vector3 moveRight = transform.right * horizInput;

        controller.SimpleMove(Vector3.ClampMagnitude(moveForward + moveRight, 1f) * movementSpeed);

        if((vertInput != 0 || horizInput !=0) && OnAslope())
        {
            controller.Move(Vector3.down * controller.height / 2 * slopeForce * Time.deltaTime);
            
        }


        MovementSpeed();
        Jump();
    }

    void MovementSpeed()
    {
        if(Input.GetKey(runKey) && controller.velocity.magnitude > 0)
        {
            movementSpeed = Mathf.Lerp(movementSpeed, runSpeed, Time.deltaTime * runBuildUp);
            AsthmaManager.instance.LowerStamina(10);
            AsthmaManager.instance.LowerAsthma(5);
        }
        else
        {
            movementSpeed = Mathf.Lerp(walkSpeed, runSpeed, Time.deltaTime * runBuildUp);
        }
    }

    private bool OnAslope()
    {
        if(isJumping)
        {
            return false;
        }

        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit, controller.height
            / 2 * slopeRayLength))
        {
            if(hit.normal != Vector3.up)
            {
                return true;
            }
        }
        return false;
    }


    void Jump()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            PlayJumpSound();
            isJumping = true;
            AsthmaManager.instance.LowerStamina(1000);
            AsthmaManager.instance.LowerAsthma(700);
            StartCoroutine(JumpEvent());
        }

    }

    private IEnumerator JumpEvent()
    {
        controller.slopeLimit = 90f;

        float timeInAir = 0f;

        do
        {
            float jumpingForce = fallOff.Evaluate(timeInAir);
            controller.Move(Vector3.up * jumpingForce * jumpingMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;

            yield return null;
        }
        while (!controller.isGrounded && controller.collisionFlags != CollisionFlags.Above);
        controller.slopeLimit = 45f;
        isJumping = false;
    }

    private void PlayJumpSound()
    {
        m_AudioSource.clip = m_JumpSound;
        m_AudioSource.Play();
    }



}
