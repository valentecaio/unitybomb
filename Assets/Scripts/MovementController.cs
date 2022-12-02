using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    private AnimatedSpriteRenderer activeSpriteRenderer;

    /*
    // "new" for suppressing warning
    public new Rigidbody2D rigidbody { get; private set; }
    // runs on script init
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    */

    private void Start()
    {
        activeSpriteRenderer = spriteRendererDown;
    }

    private void Update()
    {
        if (Input.GetKey(inputUp)) {
            setDirection(Vector2.up, spriteRendererUp);
        } else if (Input.GetKey(inputDown)) {
            setDirection(Vector2.down, spriteRendererDown);
        } else if (Input.GetKey(inputLeft)) {
            setDirection(Vector2.left, spriteRendererLeft);
        } else if (Input.GetKey(inputRight)) {
            setDirection(Vector2.right, spriteRendererRight);
        } else { 
            setDirection(Vector2.zero, activeSpriteRenderer);
        }
    }

    private void FixedUpdate()
    {
        Vector2 translation = direction * speed * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + translation);
    }

    private void setDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        direction = newDirection;
        activeSpriteRenderer = spriteRenderer;

        activeSpriteRenderer.idle = (direction == Vector2.zero);

        spriteRendererUp.enabled    = (spriteRenderer == spriteRendererUp);
        spriteRendererDown.enabled  = (spriteRenderer == spriteRendererDown);
        spriteRendererLeft.enabled  = (spriteRenderer == spriteRendererLeft);
        spriteRendererRight.enabled = (spriteRenderer == spriteRendererRight);
    }
}
