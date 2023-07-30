using System.Collections;
using UnityEngine;

public class GhostControllerqweqe : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public LayerMask wallLayer;
    private Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right }; // Solo se mueve en XZ

    private void Start()
    {
        // Iniciar las corutinas para cada fantasma
        StartCoroutine(MoveGhostCoroutine());
    }

    private bool CanMove(Vector3 direction)
    {
        // Comprobar si hay una pared en la dirección indicada
        Vector3 startPosition = transform.position;
        RaycastHit hit;
        if (Physics.Raycast(startPosition, direction, out hit, 1f, wallLayer))
        {
            return false;
        }
        return true;
    }

    private Vector3 GetValidRandomDirection()
    {
        // Elegir una dirección aleatoria válida para el movimiento
        Vector3 randomDirection = directions[Random.Range(0, directions.Length)];
        while (!CanMove(randomDirection))
        {
            randomDirection = directions[Random.Range(0, directions.Length)];
        }
        return randomDirection;
    }

    private IEnumerator MoveGhostCoroutine()
    {
        while (true)
        {
            // Obtener una dirección aleatoria válida
            Vector3 moveDirection = GetValidRandomDirection();
            moveDirection.y = 0f; // Asegurar que el movimiento sea solo en el plano XZ

            // Mover el fantasma en la dirección seleccionada
            Vector3 targetPosition = transform.position + moveDirection;
            while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
                yield return null;
            }

            // Esperar un breve momento antes de elegir la siguiente dirección
            yield return new WaitForSeconds(0.5f);
        }
    }
}
