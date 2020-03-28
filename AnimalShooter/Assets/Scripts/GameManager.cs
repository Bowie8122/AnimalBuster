using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameManager>();

            return instance;
        }
    }

    [SerializeField] internal GameObject mainMenuObj;
    [SerializeField] internal GameObject mainMenuSceneObj;
    [SerializeField] internal GameObject mainGuiObj;
    [SerializeField] internal GameObject PlayerObj;
    [SerializeField] internal Text AnimalCount;
    [SerializeField] internal Text CountDown;
    [SerializeField] internal GameObject Player;

    internal int Animals = 0;
    internal float currentTime = 0f;
    internal float startingTime = 60f;
    bool GameBegan = false;

    // state machine
    internal GameFSM fsm;

    public void Awake()
    {
        fsm = new GameFSM();
        fsm.Initialize();
        GameBegan = false;
    }

    public void Start()
    {
        GotoMainMenu();
    }

    private void Update()
    {
        fsm.UpdateState();
        currentTime -= 1 * Time.deltaTime;
        CountDown.text = currentTime.ToString("0");

        if (GameBegan)
        {
            if (currentTime <= 0)
            {
                if (Animals > 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
                else
                {
                    SceneManager.LoadScene("Gewonnen");
                }
            }

            if (Animals < 1)
            {
                SceneManager.LoadScene("Gewonnen");
            }
        }
    }
    public void StartLevel()
    {
        ((PlayState)fsm.GetState(GameStateType.Play)).totalTimeInPlay = 0;
        currentTime = startingTime;
        GameBegan = true;
    }
    #region GOTO_STATE
    public void GotoMainMenu()
    {
        fsm.GotoState(GameStateType.MainMenu);
    }

    public void GotoPlay()
    {
        fsm.GotoState(GameStateType.Play);
    }

    public void GotoPause()
    {
        fsm.GotoState(GameStateType.Pause);
    }

    #endregion
    public void UpdateText()
    {
        AnimalCount.text = Animals.ToString();   
    }
}
