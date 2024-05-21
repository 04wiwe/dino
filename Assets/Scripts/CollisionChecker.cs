using UnityEngine;
public class CollisionChecker : MonoBehaviour
{
    private Collider2D _collider;
    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        CheckCollisions();
    }
    private void CheckCollisions()
    {
        Collider2D[] allColliders = FindObjectsOfType<Collider2D>();
        for (int i = 0; i < allColliders.Length; i++)
        {
            if (allColliders[i] != _collider && _collider.bounds.Intersects(allColliders[i].bounds))
            {
                Debug.Log("Collision with " + allColliders[i].gameObject.name);
            }
        }
    }
}