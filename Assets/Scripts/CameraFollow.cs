/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objetivo que la cámara debe seguir (Pac-Man)
    public float distance = 5.0f; // La distancia a la que la cámara debe seguir a Pac-Man
    public float height = 2.0f; // La altura a la que la cámara debe seguir a Pac-Man

  


    void Start()
    {
  
       
    }

    void Update()
    {
        
        transform.position = new Vector3(target.position.x, height, target.position.z - distance);

    }

    

   

    
}*/
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /*public Transform target; // El objetivo que la cámara debe seguir (Pac-Man)
     public GameObject cherry; // Referencia a la Cherry
     public float distance = 5.0f; // La distancia a la que la cámara debe seguir a Pac-Man
     public float height = 2.0f; // La altura a la que la cámara debe seguir a Pac-Man
     public float focusDuration = 3f; // La duración de la transición de la cámara
     public GameObject[] ghosts; // Los fantasmas en la escena
     public PacmanController pacmanController; // El controlador de Pac-Man

     private Vector3 originalPosition;
     private bool hasFocusOnCherryStarted = false; // Indica si la corrutina de enfoque en la Cherry ya ha comenzado

     void Start()
     {
         //transform.LookAt(target);
         transform.LookAt(cherry.transform);
         originalPosition = transform.position;
     }

     void Update()
     {
         // Solo actualizamos la posición de la cámara si no estamos enfocándonos en la Cherry

             transform.position = new Vector3(target.position.x, height, target.position.z - distance);
             transform.LookAt(target);


         // Si el puntaje es igual a 15, no estamos enfocando la cámara en la Cherry, y la corrutina no ha comenzado aún, comenzamos la corrutina
         if (pacmanController.score == 1 && target.position !=cherry.transform.position && !hasFocusOnCherryStarted)
         {
             StartCoroutine(FocusOnCherry());
         }
     }

     IEnumerator FocusOnCherry()
     {
         hasFocusOnCherryStarted = true;

         // Detenemos el movimiento del Pac-Man y los fantasmas
         pacmanController.enabled = false;
         foreach (GameObject ghost in ghosts)
         {
             ghost.GetComponent<GhostController>().enabled = false;
         }

         // Guardamos la posición original de la cámara
         Vector3 originalPosition = transform.position;

         // Centramos la cámara en la Cherry
         transform.position = cherry.transform.position + new Vector3(0, height, -distance);
         transform.LookAt(cherry.transform);

         // Esperamos 3 segundos
         yield return new WaitForSeconds(focusDuration);

         // Restauramos la posición original de la cámara
         transform.position = originalPosition;
         transform.LookAt(target);

         // Reactivamos el movimiento del Pac-Man y los fantasmas
         pacmanController.enabled = true;
         foreach (GameObject ghost in ghosts)
         {
             ghost.GetComponent<GhostController>().enabled = true;
         }

         //hasFocusOnCherryStarted = false;
     }
    */
    public Camera mainCamera; // La cámara principal que sigue a Pac-Man
    public Camera cherryCamera; // La cámara que se centra en la Cherry
    public float focusDuration = 3f; // La duración de la transición de la cámara
    public GameObject[] ghosts; // Los fantasmas en la escena
    public PacmanController pacmanController; // El controlador de Pac-Man
    public Transform target;
    public float distance = 10.0f; // La distancia a la que la cámara debe seguir a Pac-Man
    public float height = 2.0f; // La altura a la que la cámara debe seguir a Pac-Man
    private bool hasSwitchedToCherryCamera = false; // Indica si hemos cambiado a la cámara de la Cherry
    //aprivate Vector3 originalPosition;
    private Vector3 originalPosition;

    void Start()
    {
        
        
        originalPosition = transform.position;
    }

    void Update()
    {
        
            transform.position = new Vector3(target.position.x, height, target.position.z - distance);
            transform.LookAt(target);
        

        // Si el puntaje es igual a 15, no hemos cambiado a la cámara de la Cherry, comenzamos la corrutina
        if (pacmanController.score == 15 && !hasSwitchedToCherryCamera)
        {
            StartCoroutine(SwitchCamera());
        }
    }

    IEnumerator SwitchCamera()
    {
        hasSwitchedToCherryCamera = true;

        // Detenemos el movimiento del Pac-Man y los fantasmas
        pacmanController.enabled = false;
        foreach (GameObject ghost in ghosts)
        {
            ghost.GetComponent<GhostController>().enabled = false;
        }

        // Desactivamos la cámara principal y activamos la cámara de la Cherry
        mainCamera.enabled = false;
        cherryCamera.enabled = true;

        // Esperamos 3 segundos
        yield return new WaitForSeconds(focusDuration);

        // Reactivamos la cámara principal y desactivamos la cámara de la Cherry
        mainCamera.enabled = true;
        cherryCamera.enabled = false;

        // Reactivamos el movimiento del Pac-Man y los fantasmas
        pacmanController.enabled = true;
        foreach (GameObject ghost in ghosts)
        {
            ghost.GetComponent<GhostController>().enabled = true;
        }

       // hasSwitchedToCherryCamera = false;
    }
}

