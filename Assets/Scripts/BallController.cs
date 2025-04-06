using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _forceBall; // Fuerza para lanzar la pelota

    private Rigidbody2D _rbBall; // Rigidbody de la pelota

    private void Awake()
    {
        _rbBall = GetComponent<Rigidbody2D>();
        _rbBall.bodyType = RigidbodyType2D.Kinematic; // Inicia la pelota como cinemática
    }

    public void ThrowBall()
    {
        if (transform.parent != null)
        {
            // Desasocia la pelota del jugador
            transform.parent = null;
            _rbBall.bodyType = RigidbodyType2D.Dynamic; // Cambia a cuerpo dinámico
            _rbBall.AddForce(Vector2.up * _forceBall, ForceMode2D.Impulse); // Aplica fuerza a la pelota
        }
    }
}
