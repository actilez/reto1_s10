/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objetivo que la c�mara debe seguir (Pac-Man)
    public float distance = 5.0f; // La distancia a la que la c�mara debe seguir a Pac-Man
    public float height = 2.0f; // La altura a la que la c�mara debe seguir a Pac-Man

  


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
    /*public Transform target; // El objetivo que la c�mara debe seguir (Pac-Man)
     public GameObject cherry; // Referencia a la Cherry
     public float distance = 5.0f; // La distancia a la que la c�mara debe seguir a Pac-Man
     public float height = 2.0f; // La altura a la que la c�mara debe seguir a Pac-Man
     public float focusDuration = 3f; // La duraci�n de la transici�n de la c�mara
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
         // Solo actualizamos la posici�n de la c�mara si no estamos enfoc�ndonos en la Cherry

             transform.position = new Vector3(target.position.x, height, target.position.z - distance);
             transform.LookAt(target);


         // Si el puntaje es igual a 15, no estamos enfocando la c�mara en la Cherry, y la corrutina no ha comenzado a�n, comenzamos la corrutina
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

         // Guardamos la posici�n original de la c�mara
         Vector3 originalPosition = transform.position;

         // Centramos la c�mara en la Cherry
         transform.position = cherry.transform.position + new Vector3(0, height, -distance);
         transform.LookAt(cherry.transform);

         // Esperamos 3 segundos
         yield return new WaitForSeconds(focusDuration);

         // Restauramos la posici�n original de la c�mara
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
    public Camera mainCamera; // La c�mara principal que sigue a Pac-Man
    public Camera cherryCamera; // La c�mara que se centra en la Cherry
    public float focusDuration = 3f; // La duraci�n de la transici�n de la c�mara
    public GameObject[] ghosts; // Los fantasmas en la escena
    public PacmanController pacmanController; // El controlador de Pac-Man
    public Transform target;
    public float distance = 10.0f; // La distancia a la que la c�mara debe seguir a Pac-Man
    public float height = 2.0f; // La altura a la que la c�mara debe seguir a Pac-Man
    private bool hasSwitchedToCherryCamera = false; // Indica si hemos cambiado a la c�mara de la Cherry
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
        

        // Si el puntaje es igual a 15, no hemos cambiado a la c�mara de la Cherry, comenzamos la corrutina
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

        // Desactivamos la c�mara principal y activamos la c�mara de la Cherry
        mainCamera.enabled = false;
        cherryCamera.enabled = true;

        // Esperamos 3 segundos
        yield return new WaitForSeconds(focusDuration);

        // Reactivamos la c�mara principal y desactivamos la c�mara de la Cherry
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

