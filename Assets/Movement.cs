using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField] private float speedMC;
    private Rigidbody2D rb;
    private Vector2 MovementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        MovementDirection = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        // Try out this delta time method??
        //rb2d.transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
    	Vector2 newPosition = rb.position + MovementDirection * speedMC * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
