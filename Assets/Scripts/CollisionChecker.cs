using UnityEngine;
public class CollisionChecker : MonoBehaviour
{
    private Collider2D _collider;
    private GameManager gameManager;
    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        _collider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if(gameManager.gameOver)
        {
            return;
        }
        CheckCollisions();
    }
    private void CheckCollisions()
    {
        Collider2D[] allColliders = FindObjectsOfType<Collider2D>();
        for (int i = 0; i < allColliders.Length; i++)
        {
            if (allColliders[i] != _collider && _collider.bounds.Intersects(allColliders[i].bounds))
            {
                gameManager.gameOver = true;
                Debug.Log("Collision with " + allColliders[i].gameObject.name);
            }
        }
    }
}