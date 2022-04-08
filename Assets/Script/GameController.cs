using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private IdleModel _idleModel;

    [SerializeField] private FloatView _moneyView;
    [SerializeField] private FloatView CafeText;
    [SerializeField] private FloatView TheText;
    [SerializeField] private FloatView JusText;
    [SerializeField] private FloatView MilkshakeText;
    [SerializeField] private FloatView PatisserieText;

    [SerializeField] Button _cafeButton;
    [SerializeField] Button _theButton;
    [SerializeField] Button _jusButton;
    [SerializeField] Button _MilkButton;
    [SerializeField] Button _patisserieButton;




    /*
    public int autoClicksPerSecond;
    public int minimumClicksToUnlockUpgrade;
    */

    void Start()
    {
        _idleModel = new IdleModel();
        _idleModel.GetMoney().Subscribe(_moneyView);
        _idleModel.GetCafePrixUp().Subscribe(CafeText);
        _idleModel.GetThePrixUp().Subscribe(TheText);
        _idleModel.GetJusPrixUp().Subscribe(JusText);
        _idleModel.GetMilkPrixUp().Subscribe(MilkshakeText);
        _idleModel.GetPatisseriePrixUp().Subscribe(PatisserieText);

        //Attachement button cafe
        _cafeButton.onClick.AddListener(ButtonCafe);
        //Attachement button Thé
        _theButton.onClick.AddListener(ButtonThe);
        //Attachement button Jus
        _jusButton.onClick.AddListener(ButtonJus);
        //Attachement button Milkshake
        _MilkButton.onClick.AddListener(ButtonMilk);
        //Attachement button Patisserie 
        _patisserieButton.onClick.AddListener(ButtonPatisserie);


    }


    void Update()
    {
        /*
        if (hasUpgrade)
        {
            Money += autoClicksPerSecond * Time.deltaTime;
            ClicksTotalText.text = Money.ToString("0");
        }
        */
    }


    public void OnClickMoney()
    {
        Debug.Log(_idleModel.GetMoney().GetValue());
        _idleModel.AddMoney(_idleModel.GetCafeIncome().GetValue());
        _idleModel.AddMoney(_idleModel.GetTheIncome().GetValue());
        _idleModel.AddMoney(_idleModel.GetJusIncome().GetValue());
        _idleModel.AddMoney(_idleModel.GetMilkIncome().GetValue());
        _idleModel.AddMoney(_idleModel.GetPatisseriIncome().GetValue());
    }
    public void AutoClickUpgrade()
    {
        /*
        if (!hasUpgrade && Money >= minimumClicksToUnlockUpgrade)
        {

            hasUpgrade = true;
        }
        */
    }
    public void ButtonCafe()
    {
        if (_idleModel.GetMoney().GetValue() >= _idleModel.GetCafePrixUp().GetValue())
        {
            _idleModel.UpgradeCafe();
        }


        /*
        if (!cafeUp && TotalClicks >= _idleModel.GetCafePrixUp())
        {

            TotalClicks -= cafePrixUp;
            cafeUp = true;
            cafePrixUp = cafePrixUp * 2;
            CafeText.text = cafePrixUp.ToString("0$");
        }
        else
        {
            cafeUp = false;
        }
        Debug.Log(cafePrixUp);*/

    }

    public void ButtonThe()
    {
        if (_idleModel.GetThePrixUp().GetValue() <= _idleModel.GetMoney().GetValue())
        {
            _idleModel.UpgradeThe();
        }

    }

    public void ButtonJus()
    {
        if (_idleModel.GetJusPrixUp().GetValue() <= _idleModel.GetMoney().GetValue())
        {
            _idleModel.UpgradeJus();
        }

    }

    public void ButtonMilk()
    {
        if (_idleModel.GetMilkPrixUp().GetValue() <= _idleModel.GetMoney().GetValue())
        {
            _idleModel.UpgradeMilk();
        }

    }

    public void ButtonPatisserie()
    {
        if (_idleModel.GetPatisseriePrixUp().GetValue() <= _idleModel.GetMoney().GetValue())
        {
            _idleModel.UpgradePatisserie();
        }

    }






}
