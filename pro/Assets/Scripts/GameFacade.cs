using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 既是外观模式，又是中介者
/// </summary>
public class GameFacade{

    private bool mIsGameOver;

    private static GameFacade instance;
    private GameFacade()
    {
        mIsGameOver = false;
    }

    public static GameFacade Instance {
        get {
            if (instance == null)
                instance = new GameFacade();
            return instance;
        }
    }

    public bool IsGameOver
    {
        get
        {
            return mIsGameOver;
        }

        set
        {
            mIsGameOver = value;
        }
    }

    private ArchievementSystem mArchievementSystem;
    private CampSystem mCampSystem;
    private CharacterSystem mCharacterSystem;
    private EnergySystem mEnergySystem;
    private GameEventSystem mGameEventSystem;
    private StageSystem mStageSystem;

    private CampInfoUI mCampInfoUI;
    private GamePauseUI mGamePauseUI;
    private GameStateInfoUI mGameStateInfoUI;
    private SoldierInfoUI mSoldierInfoUI;

    public void Init()
    {
        mArchievementSystem = new ArchievementSystem();
        mCampSystem = new CampSystem();
        mCharacterSystem = new CharacterSystem();
        mEnergySystem = new EnergySystem();
        mGameEventSystem = new GameEventSystem();
        mStageSystem = new StageSystem();

        mCampInfoUI = new CampInfoUI();
        mGamePauseUI = new GamePauseUI();
        mGameStateInfoUI = new GameStateInfoUI();
        mSoldierInfoUI = new SoldierInfoUI();

        mArchievementSystem.Init();
        mCampSystem.Init();
        mCharacterSystem.Init();
        mEnergySystem.Init();
        mGameEventSystem.Init();
        mStageSystem.Init();

        mCampInfoUI.Init();
        mGamePauseUI.Init();
        mGameStateInfoUI.Init();
        mSoldierInfoUI.Init();

        LoadMemento();

    }

    public void Update()
    {
        mArchievementSystem.Update();
        mCampSystem.Update();
        mCharacterSystem.Update();
        mEnergySystem.Update();
        mGameEventSystem.Update();
        mStageSystem.Update();

        mCampInfoUI.Update();
        mGamePauseUI.Update();
        mGameStateInfoUI.Update();
        mSoldierInfoUI.Update();
    }

    public void Release()
    {
        mArchievementSystem.Release();
        mCampSystem.Release();
        mCharacterSystem.Release();
        mEnergySystem.Release();
        mGameEventSystem.Release();
        mStageSystem.Release();

        mCampInfoUI.Release();
        mGamePauseUI.Release();
        mGameStateInfoUI.Release();
        mSoldierInfoUI.Release();
        CreateMemento();
    }

    public Vector3 GetEnemyTargetPos()
    {
        return mStageSystem.TargetPosition;
    }

    public void showCampInfo(ICamp camp)
    {
        mCampInfoUI.showCampInfo(camp);
    }

    public void addSoldier(ISoldier soldier)
    {
        mCharacterSystem.addSoldier(soldier);
    }

    public void addEnemy(IEnemy enemy)
    {
        mCharacterSystem.addEnemy(enemy);
    }
    public bool takeEnergy(int value)
    {
        return mEnergySystem.takeEnergy(value);
    }

    public void showMsg(string msg)
    {
        mGameStateInfoUI.ShowMsg(msg);
    }
    public void RecycleEnergy(int value)
    {
        mEnergySystem.RecycleEnergy(value);
    }

    public void UpdateEnergySilder(int energy, int max)
    {
        mGameStateInfoUI.UpdateEnergySlider(energy, max);
    }
    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mGameEventSystem.RegisterObserver(eventType, observer);
    }

    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mGameEventSystem.RemoveObserver(eventType, observer);
    }
    public void NotifySubject(GameEventType eventType)
    {
        mGameEventSystem.NotifySubject(eventType);
    }

    public void LoadMemento()
    {
        AchievementMemento memento = new AchievementMemento();
        memento.LoadData();
        mArchievementSystem.SetMemento(memento);
    }

    public void CreateMemento()
    {
        AchievementMemento memento = mArchievementSystem.CreateMemento();
        memento.SaveData();
    }

}
