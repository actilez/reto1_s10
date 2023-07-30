using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PacmanController : MonoBehaviour
{
    // Start is called before the first frame update

    private int score = 0;
    public TextMeshProUGUI scoreText;
    public GhostController[] ghosts;
    public GameObject cherry; 
    public float speed = 5f;
    public float rotationSpeed = 20f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize();
        transform.position = transform.position + movement * speed * Time.deltaTime;

        if (movement != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión fue con un fantasma
        if (collision.gameObject.CompareTag("Ghost"))
        {
            // Pausar el juego
            Debug.Log(score);
            scoreText.text = "Game Over - Puntaje:" + score;

            this.enabled = false;

            // Desactivar los scripts de movimiento de los fantasmas
            foreach (GhostController ghost in ghosts)
            {
                ghost.enabled = false;
            }


        }
    }

    

    void OnTriggerEnter(Collider other)
    {
        // Verificar si la colisión fue con un punto
        if (other.gameObject.CompareTag("Dot"))
        {
            // Incrementar el contador de puntos
            score++;

            // Mostrar el contador de puntos en la consola
            Debug.Log("Score: " + score);

            // Actualizar el texto en la interfaz de usuario
            scoreText.text = "Score: " + score;
            


            // Destruir el punto
            Destroy(other.gameObject);
           
            
            if (score == 15)
            {
                cherry.SetActive(true);
            }



        }

        if (other.gameObject.CompareTag("Cherry"))
        {
            // Incrementar el contador de puntos por 100
            score += 100;

            // Actualizar el texto en la interfaz de usuario
            scoreText.text = "Score: " + score;

            // Mostrar el mensaje de "¡Ganaste!"
            scoreText.text = "¡WINNER! Final Score: " + score;

            // Destruir Cherry
            Destroy(other.gameObject);

            //descativa pacman
            this.enabled = false;

            // Desactivar los scripts de movimiento de los fantasmas
            foreach (GhostController ghost in ghosts)
            {
                ghost.enabled = false;
            }
        }
    }

}
