﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    bool alive = true;

    public float speed = 5;
    public float horizontal_speed = 8;
    [SerializeField] Rigidbody rb;

    public float speedIncreasePerPoint = 0.1f;

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;

        Vector3 horizontalMove = (
            Input.acceleration.x +
            System.Convert.ToInt32(Input.GetKey(KeyCode.RightArrow)) -
            System.Convert.ToInt32(Input.GetKey(KeyCode.LeftArrow))) *
            transform.right * horizontal_speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        // Restart the game
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}