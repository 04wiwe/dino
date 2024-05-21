using UnityEngine;
public class Player : MonoBehaviour
{
    public float jumpForce = 20.0f;
    public  float gravity = 60.0f;
    private bool isGrounded = true;
    private Vector3 velocity = Vector3.zero;
    private void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpForce;
            isGrounded = false;
        }
        velocity.y -= gravity * Time.deltaTime;
        transform.Translate(velocity * Time.deltaTime);
        if (transform.position.y <= -3f)
        {
            isGrounded = true;
            velocity.y = 0;
            transform.position = new Vector3(transform.position.x, -3f);
        }
    }
}