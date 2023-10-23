using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody2D rigidbody2d;
    [SerializeField][Range(0, 10)] private float speed = 2;

    void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rigidbody2d.velocity = new Vector2(0, Input.GetAxis("Vertical") * speed);
    }
}
