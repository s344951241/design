using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameStateInfoUI : IUI {

    private List<GameObject> mHearts;
    private Text mSoldierCount;
    private Text mEnemyCount;
    private Text mCurrentStage;
    private Button mPauseBtn;
    private GameObject mGameOverUI;
    private Button mBackMenuBtn;
    private Text mMessage;
    private Slider mEnergySlider;
    private Text mEnergyText;

    private float mMsgTimer = 0;
    private float mMsgTime = 2;
    private AliveCountVisitor mAliveCountVisitor = new AliveCountVisitor();
    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GameStateUI");

        GameObject heart1 = UnityTool.FindChild(mRootUI, "heart1");
        GameObject heart2 = UnityTool.FindChild(mRootUI, "heart2");
        GameObject heart3 = UnityTool.FindChild(mRootUI, "heart3");
        mHearts = new List<GameObject>();
        mHearts.Add(heart1);
        mHearts.Add(heart2);
        mHearts.Add(heart3);
        mSoldierCount = UITool.FindChild<Text>(mRootUI, "SoldierCount");

        mEnemyCount = UITool.FindChild<Text>(mRootUI, "EnemyCount");
        mCurrentStage = UITool.FindChild<Text>(mRootUI, "count");
        mPauseBtn = UITool.FindChild<Button>(mRootUI, "PauseBtn");
        mGameOverUI = UnityTool.FindChild(mRootUI, "GameOver");
        mBackMenuBtn = UITool.FindChild<Button>(mRootUI, "Button");
       // mMessage = UITool.FindChild<Text>(mRootUI, "Message");
        mEnergySlider = UITool.FindChild<Slider>(mRootUI, "EnergySlider");
        mEnergyText = UITool.FindChild<Text>(mRootUI, "EnergyText");
        mMessage = UITool.FindChild<Text>(mRootUI, "Message");
        mMessage.text = "";
        mGameOverUI.SetActive(false);
    }
    public override void Update()
    {
        base.Update();
        UpdateAliveCount();
        if (mMsgTimer > 0)
        {
            mMsgTimer -= Time.deltaTime;
            if (mMsgTimer <= 0)
            {
                mMessage.text = "";
            }
        }

    }
    public void ShowMsg(string msg)
    {
        mMessage.text = msg;
        mMsgTimer = mMsgTime;
    }

    public void UpdateEnergySlider(int nowEnergy, int maxEnergy)
    {
        mEnergySlider.value = (float)nowEnergy / maxEnergy;
        mEnergyText.text = "(" + nowEnergy + "/" + maxEnergy + ")";
    }
    public void UpdateAliveCount()
    {
        mAliveCountVisitor.Reset();
        mFacade.RunVisitor(mAliveCountVisitor);
        mSoldierCount.text = mAliveCountVisitor.SoldierCount.ToString();
        mEnemyCount.text = mAliveCountVisitor.EnemyCount.ToString();
    }
}
