using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour {

    [SerializeField] private float speedMC = 3f;
    private Rigidbody2D rb;
    private Vector2 MovementDirection;
    private PlayerInput playerInput;
    private Vector2 Input;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
	playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
	Input = playerInput.actions["Move"].ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
    	Vector2 newPosition = rb.position + Input * speedMC * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
