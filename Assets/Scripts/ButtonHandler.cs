using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject pacman; // Aqu� va la referencia al objeto de Pac-Man
    //public GameObject pacmanWinner; // Aqu� va la referencia al objeto de Pac-Man Winner
    public GameObject[] ghosts; // Aqu� van las referencias a los objetos de los fantasmas
    public Button startButton; // Aqu� va la referencia al bot�n de inicio
    public Button resetButton;// Aqu� va la referencia al bot�n de reset
    private bool isGameActive = false; // Para mantener un seguimiento de si el juego est� activo o no
    

    public void StartGame() // Esta funci�n se llamar� cuando se presione el bot�n
    {
        isGameActive = !isGameActive; // Cambiar el estado del juego
        //pacman.SetActive(false);

        // Si el juego est� activo, mostrar Pac-Man y los fantasmas
        if (isGameActive)
        {
            startButton.gameObject.SetActive(false);
            pacman.SetActive(true);
            
            foreach (GameObject ghost in ghosts)
            {
                ghost.SetActive(true);
            }
        }
        // Si el juego no est� activo, ocultar Pac-Man y los fantasmas
        else
        {
            pacman.SetActive(false);

            foreach (GameObject ghost in ghosts)
            {
                ghost.SetActive(false);
            }

            startButton.gameObject.SetActive(true);
        }

        
    }

    public void ResetGame() // Esta funci�n se llamar� cuando se presione el bot�n de reinicio
    {
        // Reiniciar el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameActive = false;
        StartGame();

        // Ocultar el bot�n de reinicio
        resetButton.gameObject.SetActive(false);

        
    }
}
