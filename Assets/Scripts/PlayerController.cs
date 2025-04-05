using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields
    [SerializeField] private float _speedPlayer;

    private Rigidbody2D _rbPlayer;
    private float _unitVector;

    #endregion

    #region  Methods
    private void Movement()
    {
        if (_unitVector != 0)
            _rbPlayer.linearVelocityX = _unitVector * _speedPlayer;

    }

    #endregion

    #region Unity Callbacks
    private void Start()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _unitVector = Input.GetAxis("Horizontal");
        Movement();
    }

    #endregion
}
