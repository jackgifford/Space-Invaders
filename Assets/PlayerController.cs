using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject bullet;

    private Animator playerAnimator;
    private Rigidbody2D playerBody;


    // Use this for initialization
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalMovement = Input.GetAxis("Horizontal");
        if (horizontalMovement != 0)
        {
            playerBody.velocity = Vector2.zero;
            playerBody.AddForce(new Vector2(horizontalMovement, 0) * speed);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            MissilePooler.Instance.FireMissile(transform.position);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        playerAnimator.SetTrigger("Killed");
    }
}
