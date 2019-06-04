using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameRuler : MonoBehaviour
{
    public static GameRuler instance;

    private Button fireButton;

    [SerializeField]
    private GameObject needle, endScreen, highScore;

    private GameObject[] needles;

    [SerializeField]
    private int needlesAmmount;

    [SerializeField]
    private float needleDistance = 0.4f;

    private int needleIndex;
    private bool canFire;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        fireButton = GameObject.Find("FireButton").GetComponent<Button>();
        fireButton.onClick.AddListener(() => FireNeedle());
    }

    private void Start()
    {
        Time.timeScale = 1;
        CreateNeedles();
        canFire = true;
    }

    public void FireNeedle()
    {
        if (canFire)
        {
            StartCoroutine(Fire());
        }
    }

    private IEnumerator Fire()
    {
        canFire = false;
        needles[needleIndex].GetComponent<NeedleMovement>().FireTheNeedle();
        needleIndex++;
        yield return new WaitForSeconds(0.3f);
        canFire = true;
        if (needleIndex == needles.Length)
        {
            StartCoroutine(RefreshNeedles());
        }
    }

    private IEnumerator RefreshNeedles()
    {
        canFire = false;
        yield return new WaitForSeconds(0.3f);
        CreateNeedles();
        needleIndex = 0;
        canFire = true;
    }

    void CreateNeedles()
    {
        needles = new GameObject[needlesAmmount];
        Vector3 temp = transform.position;
        for (int i = 0; i < needles.Length; i++)
        {
            needles[i] = Instantiate(needle, temp, Quaternion.identity) as GameObject;
            temp.y -= needleDistance;
        }
    }

    public void EndGame()
    {
        int tempScore = PlayerPrefs.GetInt("maxscore");
        if (ScoreRuler.instance.score > tempScore) {
            PlayerPrefs.SetInt("maxscore", ScoreRuler.instance.score);
            ScoreRuler.instance.SetHighScore();
        }
        highScore.SetActive(false);
        Time.timeScale = 0;
        endScreen.SetActive(true);
    }

    public void ClickRestart() {
        SceneManager.LoadScene("Game");
    }

    public void ClickQuit() {
        SceneManager.LoadScene("MainMenu");
    }
}
