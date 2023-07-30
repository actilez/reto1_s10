using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objetivo que la c�mara debe seguir (Pac-Man)
    public float distance = 5.0f; // La distancia a la que la c�mara debe seguir a Pac-Man
    public float height = 2.0f; // La altura a la que la c�mara debe seguir a Pac-Man

    void Update()
    {
        // Actualizar la posici�n de la c�mara para seguir a Pac-Man
        //transform.position = target.position - target.forward * distance + Vector3.up * height;
        transform.position = new Vector3(target.position.x, height, target.position.z - distance);
        // Hacer que la c�mara mire siempre a Pac-Man
        //transform.LookAt(target);
    }
}