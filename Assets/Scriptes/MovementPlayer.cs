using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] float _Speed;
    [SerializeField] float _Horizontal;
    [SerializeField] Transform _GroundPsition;
    [SerializeField] LayerMask _LayerMask;
    [SerializeField] float _JumpForse;
    [SerializeField] float _MaxJump = 2;
    private float _CountJump = 1;
    private Rigidbody2D _rb;
    [SerializeField] Animator animator;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        MovePlayer();
        Jump();
    }

    private void MovePlayer()
    {
        animator.SetFloat("Blend", 0f);
        _Horizontal = Input.GetAxis("Horizontal");
        if (_Horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // رو به راست
            animator.SetFloat("Blend", 1f);
        }
        else if(_Horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); 
            animator.SetFloat("Blend", -1f);
        }
            Vector2 movement = new(_Horizontal * _Speed, _rb.linearVelocity.y);
        _rb.linearVelocity = movement;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement = new Vector2(_Horizontal * _Speed * 2, _rb.linearVelocity.y);
            _rb.linearVelocity = movement;
        }
    }

    private void Jump()
    {
        if (Physics2D.OverlapCircle(_GroundPsition.position, 0.01f, _LayerMask) == true)
        {
            _CountJump = 1;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.linearVelocity = new(_rb.linearVelocity.x, _JumpForse);
            }
        }
        else if (_CountJump < _MaxJump && Input.GetKeyDown(KeyCode.Space))
        {
            _CountJump++;
            _rb.linearVelocity = new(_rb.linearVelocity.x, _JumpForse);
        }
    }
}