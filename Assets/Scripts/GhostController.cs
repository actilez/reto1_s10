using System.Collections;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 5.0f;
    public float decisionTime = 1.0f;
    private Vector3 direction;
    private int layerMask;

    private void Start()
    {
        // Obtener el número de la capa Wall
        layerMask = 1 << LayerMask.NameToLayer("Wall");

        // Iniciar la corrutina que controla el movimiento del fantasma
        StartCoroutine(ChangeDirection());
    }

    private void Update()
    {
        // Mover y girar el fantasma
        MoveAndRotate();
    }

    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            // Generar un número aleatorio
            int randomNum = Random.Range(0, 2);

            // Decidir la dirección basándonos en el número aleatorio
            if (randomNum == 0)
            {
                // Moverse en el eje X
                direction = new Vector3(Random.Range(-1, 2), 0, 0);
            }
            else
            {
                // Moverse en el eje Z
                direction = new Vector3(0, 0, Random.Range(-1, 2));
            }

            // Si la nueva dirección colide con una pared, seguir intentando hasta encontrar una dirección válida
            while (Physics.Raycast(transform.position, direction, 1f, layerMask))
            {
                randomNum = Random.Range(0, 2);

                if (randomNum == 0)
                {
                    direction = new Vector3(Random.Range(-1, 2), 0, 0);
                }
                else
                {
                    direction = new Vector3(0, 0, Random.Range(-1, 2));
                }

                yield return null;
            }

            // Esperar un tiempo antes de decidir una nueva dirección
            yield return new WaitForSeconds(decisionTime);
        }
    }

    private void MoveAndRotate()
    {
        // Normalizar la dirección
        Vector3 movement = direction.normalized;

        // Mover el fantasma
        transform.position = transform.position + movement * speed * Time.deltaTime;

        // Girar el fantasma hacia la dirección de movimiento
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            targetRotation *= Quaternion.Euler(-90, 0, 90); // Añadir rotación adicional en el eje X
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

   
}
