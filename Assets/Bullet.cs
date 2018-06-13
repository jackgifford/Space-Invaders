using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bulletBody;
    private Renderer bulletRenderer;
    // Use this for initialization
    void Start()
    {
        bulletBody = GetComponent<Rigidbody2D>();
        bulletRenderer = GetComponent<Renderer>();
        bulletBody.velocity = new Vector2(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (!bulletRenderer.isVisible)
            Destroyer();
    }

    public void Destroyer()
    {
        bulletBody.velocity = Vector2.zero;
        Destroy(gameObject);
        MissilePooler.Instance.deployedMissiles--;
    }



}
