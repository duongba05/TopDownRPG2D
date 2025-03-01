using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private bool facingLeft = false;
    private bool isDashing = false;
    public static PlayerController Instance;
    public bool FacingLeft { get {return facingLeft;}}
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float dashSpeed = 4f;
    [SerializeField] private TrailRenderer myTrailRenderer;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    private float startingMoveSpeed;
    private void Awake()
    {
        Instance = this;
        playerControls = new PlayerControls();
        rb= GetComponent<Rigidbody2D>(); 
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        playerControls.Combat.Dash.performed += _ => Dash();
        startingMoveSpeed = moveSpeed;
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void Update()
    {
        PlayerInput();
    }
    private void FixedUpdate()
    {
        AgjustPlayerFacingDirection();
        Move();
    }
    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }
    private void Move()
    {
        rb.MovePosition(rb.position + movement *(moveSpeed*Time.fixedDeltaTime));
    }
    private void AgjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRenderer.flipX = true;
            facingLeft = true;
        }
        else
        {
            mySpriteRenderer.flipX= false;
            facingLeft = false;
        }
    }
    private void Dash()
    {
        if (!isDashing)
        {
            isDashing = true;
            moveSpeed *= dashSpeed;
            myTrailRenderer.emitting = true;
            StartCoroutine(EndDashCoroutine());
        }
    }
    private IEnumerator EndDashCoroutine()
    {
        float dashTime = 2f;
        float dashCD = .25f;
        yield return new WaitForSeconds(dashTime);
        moveSpeed= startingMoveSpeed;
        myTrailRenderer.emitting=false;
        yield return new WaitForSeconds(dashCD);
        isDashing=false;    
    }
}
