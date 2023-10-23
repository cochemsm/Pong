using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Ball : MonoBehaviour {
    private const string V = "PlayerOne";
    Rigidbody2D rigidbody2d;
    public Vector2 initialVelocity;
    Vector3 initialPosition;
    [SerializeField] private TextMeshProUGUI textOne;
    [SerializeField] private TextMeshProUGUI textTwo;
    private int scoreOne = 0;
    private int scoreTwo = 0;
    bool pause = false;

    void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        textOne.text = Convert.ToString(scoreOne);
        textTwo.text = Convert.ToString(scoreTwo);
    }

    private void Start() {
        rigidbody2d.velocity = initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Rigidbody2D>()) {
            rigidbody2d.velocity = (rigidbody2d.velocity + collision.gameObject.GetComponent<Rigidbody2D>().velocity).normalized * rigidbody2d.velocity.magnitude;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        pause = true;
        transform.position = initialPosition;
        
        if (collision.gameObject.name == "TriggerOne") {
            scoreTwo++;
            textTwo.text = Convert.ToString(scoreTwo);
        } else {
            scoreOne++;
            textOne.text = Convert.ToString(scoreOne);
        }

        StartCoroutine(Pause(new Vector2(-rigidbody2d.velocity.x, 0)));
        rigidbody2d.velocity = Vector2.zero;
    }

    private IEnumerator Pause(Vector2 speed) {
        yield return new WaitForSeconds(2f);
        rigidbody2d.velocity = speed;
    }

    private void FixedUpdate() {
        if (rigidbody2d.velocity.x < Mathf.Sign(rigidbody2d.velocity.x) * 5 && !pause) {
            rigidbody2d.velocity = new Vector2(Mathf.Sign(rigidbody2d.velocity.x) * 5, rigidbody2d.velocity.y);
        }
    }
}
