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
        SceneManager.LoadScene("test");
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
