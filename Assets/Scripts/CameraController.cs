﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] GameObject player;
    Vector3 offset;


    void Awake()
    {

        offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = player.transform.position + offset;

    }
}