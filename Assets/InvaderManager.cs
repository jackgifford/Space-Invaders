using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderManager : MonoBehaviour
{
    public int colCount;
    public int rowCount;
    public GameObject invader;
    public float scrollSpeed;
    public float dropCount;

    private static InvaderManager _instance;
    public static InvaderManager Instance { get { return _instance; } }
    
    private Rigidbody2D invaderMover;
    private Vector2 currVelo;
    private GameObject[] invaderArr;
    private AudioSource destroyedSound;
    private float Cooldown = 0.1f;
    private float LastCalled = 0;


    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);

        else
            _instance = this;
    }


    // Use this for initialization
    void Start()
    {
        invaderMover = GetComponent<Rigidbody2D>();
        invaderMover.velocity = new Vector2(scrollSpeed, 0);
        currVelo = transform.position;
        destroyedSound = GetComponent<AudioSource>();

        invaderArr = new GameObject[colCount * rowCount];
        float startX = 0;
        float startY = 0;

        int currCount = 0;

        for (int i = 0; i < colCount * rowCount; i++)
        {
            invaderArr[i] = Instantiate(invader, (Vector2)transform.position + new Vector2(startX, startY), Quaternion.identity);
            invaderArr[i].transform.parent = gameObject.transform;

            startX += 0.65f;
            currCount++;
            if (currCount == colCount)
            {
                startX = 0;
                currCount = 0;
                startY -= 0.5f;
            }

        }
    }
    
    public void ChangeInvaderMovement()
    {
        if (Time.time < Cooldown + LastCalled)
            return;

        var xVelocity = ((invaderMover.velocity).x > 0) ? -scrollSpeed : scrollSpeed;
        if (xVelocity > 0)
            Debug.Log("Oh Shit");
        invaderMover.velocity = new Vector2(xVelocity, 0);
        invaderMover.transform.position = (Vector2)invaderMover.transform.position + new Vector2(0, -dropCount);
        IncreaseSpeed();
        currVelo = transform.position;
        LastCalled = Time.time;
    }

    public void IncreaseSpeed()
    {
        scrollSpeed += 0.1f;
    }

    public void InvaderDestroyed()
    {
        destroyedSound.Play();
        IncreaseSpeed();
    }

    public void FireProjectile()
    {
        invaderArr[1].GetComponent<Invader>().Fire();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
