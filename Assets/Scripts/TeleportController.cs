using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public Transform teleportLocation; // Ubicación a la que se teletransportará el personaje
    public float teleportOffset = 1.0f; // La distancia a la que el personaje aparecerá del punto de teletransporte

    void OnTriggerEnter(Collider other)
    {
        // Verificar si la colisión fue con Pac-Man o un fantasma
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ghost"))
        {
            // Teletransportar al personaje a la ubicación de teletransporte con un offset a la izquierda
            other.transform.position = teleportLocation.position - teleportLocation.right * teleportOffset;
        }
    }
}
