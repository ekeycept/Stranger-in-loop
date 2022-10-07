using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController _CharacterController;
    private Vector3 moveDirection;
    private Vector3 moveDirection2;
    private float velocity;

    [SerializeField] private int speed = 10;
    [SerializeField] private float jumpHeight = 2;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float checkGroundRadius = 0.4f;

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheckerPivot;

    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject jumpButton;
    [SerializeField] private Button RestartButton;
    [SerializeField] private Button ExitButton;
    
    private Animator animator;
    public bool isJumping = false;
    public bool isRunning = false;
    private bool isDestroyed = false;

    public InterstitialsAds IntAds;

    [SerializeField] private Camera secondCamera;
    [SerializeField] private AudioSource music;

    private void Awake()
    {
        isDestroyed = false;
        _CharacterController = GetComponent<CharacterController>();
        animator = GameObject.FindGameObjectWithTag("Character").GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDestroyed == false)
        {
            if (IsOnTheGround() && velocity < 0)
            {
                velocity = -2;
            }
            Move(moveDirection);
            Move(moveDirection2);
            DoGravity();
        }
    }

    private void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection2 = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        if (moveDirection != new Vector3(0, 0, 0) || moveDirection2 != new Vector3(0, 0, 0))
            animator.SetBool("isRunning", true);
        else
            animator.SetBool("isRunning", false);

        if (Input.GetKeyDown(KeyCode.Space) && IsOnTheGround())
        {
            Jump();
        }
    }

    private bool IsOnTheGround()
    {
        bool result = Physics.CheckSphere(groundCheckerPivot.position, checkGroundRadius, groundMask);
        return result;
    }

    private void Move(Vector3 direction)
    {
        _CharacterController.Move(speed * Time.deltaTime * direction);
    }

    private void DoGravity()
    {
        velocity += gravity * Time.deltaTime;
        _CharacterController.Move(velocity * Time.deltaTime * Vector3.up);
    }

    public void Jump()
    {
        if(IsOnTheGround())
            velocity = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("DeathPlatform"))
        {
            isDestroyed = true;
            music.Stop();
            IntAds.ShowAd();
            secondCamera.gameObject.SetActive(true);
            Destroy(gameObject);
            RestartButton.gameObject.SetActive(true);
            ExitButton.gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("LevelManager").GetComponent<SaveManager>().SaveScore();
        }
    }
}
