using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePooler : MonoBehaviour
{
    private static MissilePooler _instance;
    public static MissilePooler Instance { get { return _instance; } }

    public GameObject bullet;

    public int missileCount;
    public int deployedMissiles;

    private AudioSource shootAudio;

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
        shootAudio = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireMissile(Vector2 playerPosition)
    {
        if (deployedMissiles < missileCount)
        {
            Debug.Log(deployedMissiles);
            Debug.Log(missileCount);
            deployedMissiles++;
            shootAudio.Play();
            Instantiate(bullet, playerPosition + new Vector2(0, 0.8f), Quaternion.identity);
        }
    }
}
