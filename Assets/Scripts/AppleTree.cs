﻿using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

    public GameObject applePrefab;
    public float speed = 1f;
	public float difficulty = 1f;
	public float dropDifficulty = 0f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;

    void Start()
    {
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += (speed * difficulty) * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }

		difficulty += Time.deltaTime / 10;
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }

}