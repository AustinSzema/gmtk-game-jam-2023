using UnityEngine;
using Random = System.Random;

public class AutoMove : MonoBehaviour
{
  [SerializeField] private Rigidbody2D rb;
  [SerializeField] private float moveSpeed = 5f;
  [SerializeField] private float triggerJumpDistance = 1f;
  [SerializeField] private float jumpForce = 10f;
  [SerializeField] private bool _move = false;

  private float moveDirection = 1f;
  private Collider2D _collider2D;
  [SerializeField] private bool isGrounded;
  RaycastHit2D wallCast;
    private Duster duster;
    [SerializeField] private AudioClip[] jumpSfx;
    private int _numJumpSfx;

  [SerializeField] private LayerMask whatIsWall;
  [SerializeField] private LayerMask whatIsGround;

  [SerializeField] private Transform footPosition;
  [SerializeField] private Transform frontPosition;

  void FixedUpdate()
  {
    if (GameController.editing)
    {
      rb.Sleep();
      _collider2D.enabled = false;
    }
    else
    {
      rb.WakeUp();
      _collider2D.enabled = true;
    }

    if (_move)
    {
      wallCast = Physics2D.BoxCast(transform.position, new Vector2(triggerJumpDistance, transform.localScale.y), 00f,
        transform.right, triggerJumpDistance, whatIsWall);
      RaycastHit2D ray = Physics2D.BoxCast(footPosition.position, new Vector2(transform.localScale.x / 2, 0.1f), 0f,
        -transform.up, 0.1f, whatIsGround);
      isGrounded = ray;

      if (wallCast)
      {
        Debug.Log("attempting to jump");
        Jump();
      }

      /*if (Physics2D.BoxCast(transform.position, new Vector2(0.1f, transform.localScale.y), 00f, transform.right, 0.1f))
      {
          FlipDirection();
      }*/

      Move();
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (Physics2D.BoxCast(frontPosition.position, new Vector2(0.1f, transform.localScale.y), 00f, transform.right, 0.1f,
          whatIsWall))
    {
      FlipDirection();
    }
  }

  private void Start()
  {
    _move = false;
    _collider2D = GetComponent<Collider2D>();
        duster = GetComponent<Duster>();
        _numJumpSfx = jumpSfx.Length;
  }

  private void OnEnable()
  {
    _move = false;
    moveDirection = 1f;
    transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
  }

  private void FlipDirection()
  {
    moveDirection *= -1f;
    Debug.Log(moveDirection);
    if (moveDirection > 0f)
    {
      transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }
    else
    {
      transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
    }
  }

  private void Jump()
  {
    if (isGrounded)
    {
      Debug.Log("is jump");
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
      AudioSource.PlayClipAtPoint(jumpSfx[UnityEngine.Random.Range(0, _numJumpSfx)], Camera.main.transform.position, .5f);
    }
  }

  private void Move()
  {
    if (_move)
    {
      rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }
  }

  public void Play()
  {
    _move = true;
  }
}