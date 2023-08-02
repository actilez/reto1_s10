using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject pacman; // Aquí va la referencia al objeto de Pac-Man
    //public GameObject pacmanWinner; // Aquí va la referencia al objeto de Pac-Man Winner
    public GameObject[] ghosts; // Aquí van las referencias a los objetos de los fantasmas
    public Button startButton; // Aquí va la referencia al botón de inicio
    public Button resetButton;// Aquí va la referencia al botón de reset
    private bool isGameActive = false; // Para mantener un seguimiento de si el juego está activo o no
    

    public void StartGame() // Esta función se llamará cuando se presione el botón
    {
        isGameActive = !isGameActive; // Cambiar el estado del juego
        //pacman.SetActive(false);

        // Si el juego está activo, mostrar Pac-Man y los fantasmas
        if (isGameActive)
        {
            startButton.gameObject.SetActive(false);
            pacman.SetActive(true);
            
            foreach (GameObject ghost in ghosts)
            {
                ghost.SetActive(true);
            }
        }
        // Si el juego no está activo, ocultar Pac-Man y los fantasmas
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

    public void ResetGame() // Esta función se llamará cuando se presione el botón de reinicio
    {
        // Reiniciar el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameActive = false;
        StartGame();

        // Ocultar el botón de reinicio
        resetButton.gameObject.SetActive(false);

        
    }
}
