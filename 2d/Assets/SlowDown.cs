using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    public PlayerMovement playmov;
    public float slowness = 5.0f;
    public GameObject arrow;
    public GameObject player;
    private Rigidbody2D rb;
    bool rotatingArrow = false;
    public float rotspeed=20;
    public float dashSpeed = 10.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rotatingArrow)
        {
            arrow.transform.RotateAround(player.transform.position, new Vector3(0, 0, 1), Time.deltaTime * rotspeed);
        }

        if (Input.GetKeyDown("x") && playmov.isJumping)
        {
            Time.timeScale = 1f / slowness;
            playmov.enabled = false;

            arrow.SetActive(true);
            rotatingArrow = true;
        }

        if (Input.GetKeyUp("x") && playmov.isJumping)
        {
            playmov.isJumping = false;
            Time.timeScale = 1.0f;

            playmov.enabled = true;
            rotatingArrow = false;
            arrow.SetActive(false);

            // Calculate the direction of the arrow's right vector after rotation
            Vector2 arrowDirection = arrow.transform.rotation * Vector2.right;
            Debug.Log(arrowDirection);
            rb.velocity = arrowDirection* dashSpeed;
        }
    }
}
