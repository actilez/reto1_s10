using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PacmanController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float rotationSpeed = 20f;
    public GameObject cherry;
    public GhostController[] ghosts;
    public Button resetButton;
    public TextMeshProUGUI scoreText;
    public AudioSource audioSource;
    public AudioSource audioCollision;
    public AudioSource audioWinner;
    public AudioSource audioEnviroment;
    public AudioSource audioExplosion;
    public GameObject explosion;
    public GameObject meshPacman;
    public int score = 0;
    /* public Transform limit1; // Referencia al objeto Limit1
     public Transform limit2; // Referencia al objeto Limit2
     public float teleportOffset = 1.0f; //distancia adelante del teleport]*/


    
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
            audioEnviroment.Stop();
            audioCollision.Play();
            
            
            scoreText.text = "Score: " + score +" ¡GAME OVER! ";

            

            // Desactivar los scripts de movimiento de los fantasmas
            foreach (GhostController ghost in ghosts)
            {
                ghost.enabled = false;
            }
            audioExplosion.Play();
            Instantiate(explosion, transform.position, transform.rotation);
            

            

            
            resetButton.gameObject.SetActive(true);
            meshPacman.GetComponent<SkinnedMeshRenderer>().enabled = false;
            this.enabled = false;
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
            //Debug.Log("Score: " + score);

            // Actualizar el texto en la interfaz de usuario
            scoreText.text = "Score: " + score;


            audioSource.Play();
            // Destruir el punto
            Destroy(other.gameObject);
           
            
            if (score == 15)
            {
                cherry.SetActive(true);
            }

        }
        /*
        if (other.gameObject.CompareTag("Limit1"))
        {
            // Teletransportar a Pac-Man a Limit2
            transform.position = limit2.position + limit2.right * teleportOffset; 
        }
        // Verificar si la colisión fue con Limit2
        else if (other.gameObject.CompareTag("Limit2"))
        {
            // Teletransportar a Pac-Man a Limit1
            transform.position = limit1.position - limit1.right * teleportOffset;
        }
        */
        if (other.gameObject.CompareTag("Cherry"))
        {   //para la música
            audioEnviroment.Stop();
            // Incrementar el contador de puntos por 100
            score += 100;

            //Sonido de ganar
            audioWinner.Play();
            

            // Actualizar el texto en la interfaz de usuario
            scoreText.text = "Score: " + score;

            // Mostrar el mensaje de "¡Ganaste!"
            scoreText.text = "Score: "+ score +" ¡WINNER! ";

            // Destruir Cherry
            Destroy(other.gameObject);

            //descativa pacman
            this.enabled = false;

            // Desactivar los scripts de movimiento de los fantasmas
            foreach (GhostController ghost in ghosts)
            {
                ghost.enabled = false;
            }

            resetButton.gameObject.SetActive(true);
        }
    }

}
