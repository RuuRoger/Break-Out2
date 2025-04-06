using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _speedPlayer;
    [SerializeField] private float _forceBall;

    private GameObject _ball;
    private Rigidbody2D _rbBall;
    private Rigidbody2D _rbPlayer;
    private float _unitVector;

    #endregion

    #region  Methods
    private void MovementPlayer()
    {
        if (_unitVector != 0)
            _rbPlayer.linearVelocityX = _unitVector * _speedPlayer;
        else
            _rbPlayer.linearVelocityX = 0f;

    }

    private void TrhowBall()
    {
        if (this.transform.childCount > 0)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _ball.transform.parent = null;
                _rbBall.bodyType = RigidbodyType2D.Dynamic;
                _rbBall.AddForce(Vector2.up * _forceBall, ForceMode2D.Impulse);
            }
        }
    }

    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        _ball = transform.Find("Ball").gameObject;
        _rbPlayer = GetComponent<Rigidbody2D>();
        _rbBall = _ball.GetComponent<Rigidbody2D>();

        _rbBall.bodyType = RigidbodyType2D.Kinematic;
    }
    private void FixedUpdate()
    {
        MovementPlayer();
    }
    private void Update()
    {
        _unitVector = Input.GetAxis("Horizontal");
        TrhowBall();
    }

    #endregion
}
