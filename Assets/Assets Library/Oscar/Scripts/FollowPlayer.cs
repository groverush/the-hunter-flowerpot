using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine.Serialization;
using UnityEngine.Assertions;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Update is called once per frame
    }

    void LateUpdate()
    {
        // Coincide la rotaci�n de la c�mara con la del jugador
        // transform.position = player.transform.position + offset;
        transform.position = player.transform.position + player.transform.TransformDirection(offset);
        transform.LookAt(player.transform.position + Vector3.up * 1.5f);
    }
}
