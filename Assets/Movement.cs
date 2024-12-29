using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField] private float speedMC = 3f;
    private Rigidbody2D rb;
    private Vector2 MovementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    //En caso de querer un efecto de deslizamiento manipular las variables de gravedad y sensibilidad
    //Para ello se debe ir a Edit > Project Settings > Input Manager
     	float MoveX = Input.GetAxisRaw("Horizontal");
     	float MoveY = Input.GetAxisRaw("Vertical"); 
     	
     	//Recordar que el movimiento debe hacerse con Input.GetAxisRaw("")
     	//Para evitar sobrescritura en los ejes
     	
        MovementDirection = new Vector2(MoveX,MoveY).normalized;

    }

    void FixedUpdate()
    {
    	Vector2 newPosition = rb.position + MovementDirection * speedMC * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
