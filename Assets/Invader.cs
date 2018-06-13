using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{

    private Animator invaderAnimator;
    // Use this for initialization
    void Start()
    {
        invaderAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Walls")
            InvaderManager.Instance.ChangeInvaderMovement();

        else
        {
            invaderAnimator.SetTrigger("Killed");
            InvaderManager.Instance.InvaderDestroyed();

            other.GetComponent<Bullet>().Destroyer();
            Destroy(gameObject, 0.2f);
        }
    }

    public void Fire()
    {
        Debug.Log("Fire called!");
    }
}
