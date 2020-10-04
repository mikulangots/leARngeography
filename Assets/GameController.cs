using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int currentFlag;
    public GameObject[] flagsUI;
    List<GameObject> flagList;
    public Button nextBtn, backBtn;
    bool marker;
    public AudioSource correctSound, winSound, errorSound;
    public GameObject winText, smileFx;
    public Text scoreTxt;
    public Animator scoreAnim;
    int score;

    void Start()
    {
        score = 0;
        instance = this;
        currentFlag = 0;
        flagList = new List<GameObject>();
        flagList.AddRange(flagsUI);
        nextBtn.onClick.AddListener(SwitchFlag);
        backBtn.onClick.AddListener(BackToMainMenu);
        marker = false;
        StartCoroutine("fixBuggedFlag");
    }
    private void FixedUpdate()
    {
        if (flagList.Count <= 1) nextBtn.onClick.RemoveAllListeners();

        if(!scoreTxt.text.Equals(score.ToString()))
        {
            scoreTxt.text = score.ToString();
        }
    }
    IEnumerator fixBuggedFlag()
    {
        flagsUI[0].SetActive(true);
        yield return null;
        flagsUI[0].SetActive(false);
        yield return new WaitForSeconds(0.4f);
        flagsUI[0].SetActive(true);
    }
    void SwitchFlag()
    {
        if(currentFlag == flagList.Count - 1 && !marker )
            flagList[currentFlag].SendMessage("SlideMeOut");

        //flagList[flagList.Count - 1].SetActive(false);
        if (currentFlag >= flagList.Count-1 || currentFlag < 0)
        {
                currentFlag = 0;
        }
        else
        {
            if(!marker) flagList[currentFlag].SendMessage("SlideMeOut");
            //flagList[currentFlag].SetActive(false);
            currentFlag++;
        }
        marker = false;
        flagList[currentFlag].SetActive(true);
    }

    public bool ClickFlag(string stateName)
    {
        if(flagList[currentFlag].name == stateName)
        {
            AddScore((int)Random.Range(80, 100));
            correctSound.Play();
            smileFx.SetActive(true);
            flagList[currentFlag].SetActive(false);
            flagList.RemoveAt(currentFlag);
            if(flagList.Count == 0)
            {
                StartCoroutine("Win");
                return true;
            }
            marker = true;
            SwitchFlag();
            return true;
        }
        errorSound.Play();
        return false;
    }

    IEnumerator Win()
    {
        nextBtn.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        winSound.Play();
        winText.SetActive(true);
        print("win");
        yield return null;
    }

    void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreAnim.SetTrigger("addScore");
    }
    void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
