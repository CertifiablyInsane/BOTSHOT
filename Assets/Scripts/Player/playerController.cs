using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    private PlayerControls playerControls;

    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform cameraBody;
    [SerializeField] private AudioClip[] footstepLibrary;

    private float yRotation = 0f;
    private float zRotation = 0f;

    private Vector3 velocity;
    private bool isGrounded;
    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;
    private float smoothInputSpeed = 0.1f;

    private Vector3 currentRot;
    private Vector3 destinationRot;

    public bool isOnWeaponCooldown = false;

    private float footstepTimer = 0;

    private CharacterController controller;
    private PlayerInput playerInput;
    private playerInventory playerInventory;
    private AudioSource currentSound;
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        playerInventory = GetComponent<playerInventory>();
        currentSound = GetComponent<AudioSource>();
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (playerControls.Generic.altfire.ReadValue<float>() == 1)
        {
            BroadcastMessage("Altfire"); //altfire takes precedence over fire
        }
        else if (playerControls.Generic.fire.ReadValue<float>() == 1)
        {
            BroadcastMessage("Shoot");
        }
        if(playerControls.Generic.use.triggered)
        {
            RaycastHit hit;
            if(Physics.Raycast(cameraBody.transform.position, cameraBody.transform.forward.normalized, out hit, 2f))
            {
                if(hit.transform.tag == "Usable")
                {
                    hit.transform.BroadcastMessage("OnUsed");
                }
            }
        }

        if(isOnWeaponCooldown == false)
        {
            if(playerControls.Generic.weapon1.triggered)
            {
                playerInventory.WeaponSwap("Pistol");
            }
            else if(playerControls.Generic.weapon2.triggered)
            {
                playerInventory.WeaponSwap("Shotgun");
            }
            else if(playerControls.Generic.weapon3.triggered)
            {
                playerInventory.WeaponSwap("GrenadeLauncher");
            }
        }
        
        controller.Move(new Vector3(0, -0.01f, 0));
        isGrounded = controller.isGrounded;
        if(isGrounded)
        {
            smoothInputSpeed = 0.1f;
            velocity.y = 0;
        }
        else
        {
            smoothInputSpeed = 0.8f;
        }

        Vector2 input = playerControls.Generic.move.ReadValue<Vector2>();
        currentInputVector = Vector2.SmoothDamp(currentInputVector, input, ref smoothInputVelocity, smoothInputSpeed);
        Vector3 move = transform.right * currentInputVector.x + transform.forward * currentInputVector.y;
        controller.Move(move * speed * Time.deltaTime);
        if((isGrounded && input.x != 0) || (isGrounded && input.y != 0))
        {
            if(footstepTimer == 0 || (footstepTimer + 0.5f < Time.fixedTime))
            {
                AudioClip sound = GetFootstepSound();
                currentSound.clip = sound;
                currentSound.Play();
                footstepTimer = Time.fixedTime;
            }
        }
        else
        {
            footstepTimer = 0;
        }

        if (playerControls.Generic.jump.triggered && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            controller.Move(velocity * Time.deltaTime);
        }

        //Apply Gravity
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

        }

        //Mouselook
        Vector2 mouseLook = playerControls.Generic.look.ReadValue<Vector2>();

        mouseLook = mouseLook * mouseSensitivity * Time.deltaTime;

        yRotation -= mouseLook.y;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        //Strafe rotation modifier

        if(isGrounded) //only apply strafe rotation if grounded
        {
            destinationRot.z = 2f * -input.x;
        }
        else //else it is straight up
        {
            destinationRot.z = 0f;
        }
        currentRot = Vector3.Lerp(currentRot, destinationRot, smoothInputSpeed);


        cameraBody.transform.localRotation = Quaternion.Euler(yRotation, 0f, currentRot.z);

        transform.Rotate(Vector3.up * mouseLook.x);
    }

    private AudioClip GetFootstepSound()
    {
        int i = Random.Range(0, 3);
        AudioClip chosen = footstepLibrary[i];
        return chosen;
    }

}
