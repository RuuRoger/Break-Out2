using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _speedPlayer; // Velocidad del jugador
    [SerializeField] private BallController _ballController; // Referencia al script BallController

    private Rigidbody2D _rbPlayer; // Rigidbody del jugador
    private float _unitVector; // Entrada del jugador (Izquierda/Derecha)

    private void Awake()
    {
        _rbPlayer = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody del jugador
    }

    private void FixedUpdate()
    {
        MovementPlayer(); // Movimiento del jugador
    }

    private void Update()
    {
        _unitVector = Input.GetAxis("Horizontal"); // Lee la entrada horizontal

        if (Input.GetKeyUp(KeyCode.Space) && _ballController != null)
        {
            _ballController.ThrowBall(); // Llama al método ThrowBall del script BallController
        }
    }

    private void MovementPlayer()
    {
        // Mueve al jugador dependiendo de la entrada
        if (_unitVector != 0)
            _rbPlayer.linearVelocityX = _unitVector * _speedPlayer;
        else
            _rbPlayer.linearVelocityX = 0f;
    }
}
