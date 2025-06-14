using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissileLaunch : MonoBehaviour
{
    public float lifeTime = 5f; // Por si no choca con nada
    public Vector3 boundsMin = new Vector3(-10f, -10f, -10f); // Ajusta seg�n el nivel
    public Vector3 boundsMax = new Vector3(10f, 10f, 10f);
    private GameManager gameManager;
    private int pointToAdd = 5; // Puntos que se suman al destruir un objetivo
    private int pointToSubtract = -3;// Puntos que se restan al destruir un objetivo
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Destruye el misil si sale del �rea del nivel
        Vector3 pos = transform.position;
        if (pos.x < boundsMin.x || pos.x > boundsMax.x ||
            pos.y < boundsMin.y || pos.y > boundsMax.y ||
            pos.z < boundsMin.z || pos.z > boundsMax.z)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Aqu� puedes verificar el tag del enemigo u objeto que quieras destruir
        if (other.CompareTag("Animal"))
        {

            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.UpdateScore(pointToAdd); // Aumenta el puntaje al destruir un objetivo
        }
        if (other.CompareTag("Fruit"))
        {

            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.UpdateScore(pointToSubtract); // Aumenta el puntaje al destruir un objetivo
        }
    }
}
