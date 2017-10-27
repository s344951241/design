using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampInfoUI : IUI {

    private Image mCampIcon;
    private Text mCampName;
    private Text mCampLv;
    private Text mWeaponLv;
    private Button mUp;
    private Button mWeaponUp;
    private Button mTrain;
    private Button mCancelTrain;
    private Text mAliveCount;
    private Text mTrainCount;
    private Text mTrainTime;

    private ICamp mCamp;

    public override void Init()
    {
        base.Init();
        mRootUI = UnityTool.FindChild(UITool.GetCanvas(),"CampInfoUI");

        mCampIcon = UITool.FindChild<Image>(mRootUI, "CampIcon");
        mCampName = UITool.FindChild<Text>(mRootUI, "CampName");
        mCampLv = UITool.FindChild<Text>(mRootUI, "CampLv");
        mWeaponLv = UITool.FindChild<Text>(mRootUI, "WeaponLv");
        mUp = UITool.FindChild<Button>(mRootUI, "CampUp");
        mWeaponUp = UITool.FindChild<Button>(mRootUI, "WeaponUp");
        mTrain = UITool.FindChild<Button>(mRootUI, "TrainBtn");
        mCancelTrain= UITool.FindChild<Button>(mRootUI, "CancelTrainBtn");
        mAliveCount = UITool.FindChild<Text>(mRootUI, "AliveCount");
        mTrainCount = UITool.FindChild<Text>(mRootUI, "TrainCount");
        mTrainTime = UITool.FindChild<Text>(mRootUI, "TrainTime");

        mTrain.onClick.AddListener(onTrainClick);
        mCancelTrain.onClick.AddListener(onCancelTrainClick);
        mUp.onClick.AddListener(OnCampUpClick);
        mWeaponUp.onClick.AddListener(OnWeaponUpClick);
        Hide();
    }
    public override void Update()
    {
        base.Update();
        if (mCamp != null)
        {
            showTrainingInfo();
        }
       
    }
    public void showCampInfo(ICamp camp)
    {
        Show();
        mCamp = camp;
        mCampIcon.sprite = FactoryManager.AssetFactory.LoadSprite(camp.Icon);
        mCampName.text = camp.Name;
        mCampLv.text = camp.Lv.ToString();
        showWeaponLv(camp.WeaponType);
        mTrain.transform.Find("Text").GetComponent<Text>().text = "训练\n" + mCamp.EnergyCostTrain + "能量";
        showTrainingInfo();
    }
    private void showTrainingInfo()
    {
        mTrainCount.text = mCamp.GetTrainCount.ToString();
        mTrainTime.text = mCamp.GetTrainRemainingTime.ToString("0.0");
        if (mCamp.GetTrainCount == 0)
        {
            mCancelTrain.interactable = false;
        }
        else
        {
            mCancelTrain.interactable = true;
        }

    }
    private void showWeaponLv(WeaponType type)
    {
        switch (type)
        {
            case WeaponType.Gun:
                mWeaponLv.text = "手枪";
                break;
            case WeaponType.Rifle:
                mWeaponLv.text = "长枪";
                break;
            case WeaponType.Rocket:
                mWeaponLv.text = "火箭";
                break;
            case WeaponType.MAX:
                break;
            default:
                break;
        }
    }

    private void onTrainClick()
    {
        int energy = mCamp.EnergyCostTrain;
        if (GameFacade.Instance.takeEnergy(energy))
        {
            mCamp.Train();
        }
        else
        {
            GameFacade.Instance.showMsg("energy is not enough to train");
        }

    }

    private void onCancelTrainClick()
    {
        mFacade.RecycleEnergy(mCamp.EnergyCostTrain);
        mCamp.CancelTrain();
    }

    private void OnCampUpClick()
    {
        int energy = mCamp.EnergyCostCampUpGrade;
        if (energy < 0)
        {
            mFacade.showMsg("camp is maxLv can't up");
            return;
        }
        if (mFacade.takeEnergy(energy))
        {
            mCamp.UpGradeCamp();
            showCampInfo(mCamp);
        }
        else
        {
            mFacade.showMsg("energy is not enough");
        }
        
    }

    private void OnWeaponUpClick()
    {
        int energy = mCamp.EnergyCostWeaponUpGrade;
        if (energy < 0)
        {
            mFacade.showMsg("weapon is maxLv can't up");
            return;
        }
        if (mFacade.takeEnergy(energy))
        {
            mCamp.UpWeaponGrade();
            showCampInfo(mCamp);
        }
        else
        {
            mFacade.showMsg("energy is not enough");
        }
        
    }
}
