using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float border = 4f;
    private Rigidbody2D rb;
    private PlayerControls controls;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new PlayerControls();
        controls.Gameplay.Jump.performed += ctx => Jump();
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    private void Jump()
    {
        if (!IsPointerOverUI())
        {
            rb.linearVelocity = new Vector2(0, jumpForce);
        }
    }

    private bool IsPointerOverUI()
    {
        return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -border, border);
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            GameManager.Instance.GameOver();
        }
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(transform.position.x, 0, 0);
        rb.linearVelocity = Vector2.zero;
    }
}
