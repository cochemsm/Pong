using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    Rigidbody2D rigidbody2d;
    public Vector2 initialVelocity;
    Vector3 initialPosition;

    void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    private void Start() {
        rigidbody2d.velocity = initialVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        transform.position = initialPosition;
        rigidbody2d.velocity = new Vector2(-rigidbody2d.velocity.x, rigidbody2d.velocity.y);
    }
}
