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
        if (name == "PlayerOne") {
            rigidbody2d.velocity = new Vector2(0, Input.GetAxisRaw("PlayerOne") * speed);
        } else {
            rigidbody2d.velocity = new Vector2(0, Input.GetAxisRaw("PlayerTwo") * speed);
        }
    }
}
