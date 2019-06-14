using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private AudioSource audioS;
    [SerializeField]private AudioClip hoverFX;

    private void Start()
    {
        audioS = GameObject.Find("audioHandler").GetComponent<AudioSource>();
    }

    public void playSound()
    {
        audioS.PlayOneShot(hoverFX);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Retry()
    {
        SceneManager.LoadScene("PlaytestOverworld");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
