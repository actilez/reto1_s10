using System.Collections;
using UnityEngine;

public class GhostControllerF : MonoBehaviour
{
    public float speed = 5.0f;
    public float decisionTime = 1.0f;
    private Vector3 direction;
    private int layerMask;

    private void Start()
    {
        // Obtener el n�mero de la capa Wall
        layerMask = 1 << LayerMask.NameToLayer("Wall");

        // Iniciar la corrutina que controla el movimiento del fantasma
        StartCoroutine(ChangeDirection());
    }

    private void Update()
    {
        // Mover el fantasma en la direcci�n actual
        Move();
    }

    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            // Generar un n�mero aleatorio
            int randomNum = Random.Range(0, 2);

            // Decidir la direcci�n bas�ndonos en el n�mero aleatorio
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

            // Si la nueva direcci�n colide con una pared, seguir intentando hasta encontrar una direcci�n v�lida
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

            // Esperar un tiempo antes de decidir una nueva direcci�n
            yield return new WaitForSeconds(decisionTime);
        }
    }

    private void Move()
    {
        // Mover el fantasma en la direcci�n actual, con interpolaci�n para movimiento suave
        transform.position = Vector3.Lerp(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
