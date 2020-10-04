using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Panel;
    public Button anyBtn, playBtn;
    public AudioSource selectSound, startSound;

    public void StartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlaySound()
    {
        if (anyBtn)
        {
            selectSound.Play();
        }
        else if (playBtn)
        {
            startSound.Play();
        }
        
    }

    public void OpenPanel()
    {
        if (Panel != null)
        {
            Animator animator = Panel.GetComponent<Animator>();
            if (animator != null)
            {
                bool isMoved = animator.GetBool("move");

                animator.SetBool("move", !isMoved);
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
