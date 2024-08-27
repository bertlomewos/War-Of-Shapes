using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    // Movement
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 direction;

    //setting bounderies 
    private Vector2 screenBound;
    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        // Set the Rigidbody
        rb = GetComponent<Rigidbody2D>();

        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        width = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewpoint = transform.position;
        viewpoint.x = Mathf.Clamp(viewpoint.x, screenBound.x + width, screenBound.x * -1 -width);
        transform.position = viewpoint;
    }
    private void FixedUpdate()
    {
        // Move the player
        if (rb != null)
        {
            rb.velocity = direction * speed * Time.fixedDeltaTime;
        }
    }
    // Access the new input system to know which direction it wants to be pushed
    private void OnMove(InputValue input) => direction = input.Get<Vector2>().normalized;
}
