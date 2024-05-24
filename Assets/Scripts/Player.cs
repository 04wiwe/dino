using UnityEngine;
public class Player : MonoBehaviour
{
    public float jumpForce = 25.0f;
    public  float gravity = 60.0f;
    private bool isGrounded = true;
    private Vector3 velocity = Vector3.zero;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if(gameManager.gameOver)
        {
            return;
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpForce;
            isGrounded = false;
        }
        velocity.y -= gravity * Time.deltaTime;
        transform.Translate(velocity * Time.deltaTime);
        if (transform.position.y <= -3.0f)
        {
            isGrounded = true;
            velocity.y = 0;
            transform.position = new Vector3(transform.position.x, -3.0f);
        }
    }
}