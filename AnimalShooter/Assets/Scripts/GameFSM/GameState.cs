using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStateType { MainMenu, Play, Pause }

public abstract class GameState
{
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}

public class MainMenuState : GameState
{
    public override void Enter()
    {
        GameManager.Instance.mainMenuObj.SetActive(true);
        GameManager.Instance.mainMenuSceneObj.SetActive(true);
        Cursor.visible = false;
        Time.timeScale = 0;
    }

    public override void Exit()
    {
        GameManager.Instance.mainMenuObj.SetActive(false);
        GameManager.Instance.mainMenuSceneObj.SetActive(false);
        Time.timeScale = 1;
    }

    public override void Update()
    {
        if (Input.anyKeyDown)
        {
            GameManager.Instance.fsm.GotoState(GameStateType.Play);
            GameManager.Instance.StartLevel();
        }
    }
}

public class PlayState : GameState
{
    internal float totalTimeInPlay = 0f;

    public override void Enter()
    {
        GameManager.Instance.mainGuiObj.SetActive(true);
        GameManager.Instance.PlayerObj.SetActive(true);
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Instance.fsm.GotoState(GameStateType.Pause);
    }
}

public class PauseState : GameState
{
    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Instance.fsm.GotoState(GameStateType.Play);
    }
}