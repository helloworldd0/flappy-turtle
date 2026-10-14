using UnityEngine;

public class ColumnMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float destroyX = -20f;

    private void Update()
    {
        transform.Translate(new Vector2(-speed *  Time.deltaTime, 0));
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
