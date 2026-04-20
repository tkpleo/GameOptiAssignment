using UnityEngine;

/// <summary>
/// Moves the GameObject downward when it is enabled/added to the scene.
/// Uses Rigidbody2D velocity if present (and enabled), otherwise uses transform translation.
/// Includes optional automatic destruction when the object goes below a Y threshold.
/// </summary>
public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool useRigidbody2D = true;
    [SerializeField] private bool destroyWhenBelow = true;
    [SerializeField] private float destroyBelowY = 2f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (useRigidbody2D && rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = Vector2.down * speed;
        }
        else
        {
            // No Rigidbody2D
        }
    }

    private void Update()
    {
        if (!(useRigidbody2D && rb != null))
        {
            // Move via transform
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (destroyWhenBelow && transform.position.y < destroyBelowY)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Change speed at runtime. If using Rigidbody2D, updates its velocity immediately.
    /// </summary>
    public float Speed
    {
        get => speed;
        set
        {
            speed = value;
            if (useRigidbody2D && rb != null)
                rb.velocity = Vector2.down * speed;
        }
    }
}
