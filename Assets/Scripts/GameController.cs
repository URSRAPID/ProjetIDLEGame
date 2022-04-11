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

    [SerializeField] private FloatView CafeTextVendeur;
    [SerializeField] private FloatView TheTextVendeur;
    [SerializeField] private FloatView JusTextVendeur;
    [SerializeField] private FloatView MilkTextVendeur;
    [SerializeField] private FloatView PatisserieTextVendeur;

    [SerializeField] Button _cafeButtonAmelioration;
    [SerializeField] Button _theButtonAmelioration;
    [SerializeField] Button _jusButtonAmelioration;
    [SerializeField] Button _MilkButtonAmelioration;
    [SerializeField] Button _patisserieButtonAmelioration;

    [SerializeField] Button _cafeButtonVendeur;
    [SerializeField] Button _theButtonVendeur;
    [SerializeField] Button _jusButtonVendeur;
    [SerializeField] Button _MilkButtonVendeur;
    [SerializeField] Button _patisserieButtonVendeur;

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


        _idleModel.GetCafeIncome().Subscribe(CafeTextVendeur);
        _idleModel.GetTheIncome().Subscribe(TheTextVendeur);
        _idleModel.GetJusIncome().Subscribe(JusTextVendeur);
        _idleModel.GetMilkIncome().Subscribe(MilkTextVendeur);
        _idleModel.GetPatisserieIncome().Subscribe(PatisserieTextVendeur);

        //Attachement button pour am�lioration de price cafe 
        _cafeButtonAmelioration.onClick.AddListener(OnClickButtonCafe);
        //Attachement button pour am�lioration de price Th�
        _theButtonAmelioration.onClick.AddListener(OnClickButtonThe);
        //Attachement button pour am�lioration de price Jus
        _jusButtonAmelioration.onClick.AddListener(OnClickButtonJus);
        //Attachement button pour am�lioration de price Milkshake
        _MilkButtonAmelioration.onClick.AddListener(OnClickButtonMilk);
        //Attachement button pour am�lioration de price Patisserie 
        _patisserieButtonAmelioration.onClick.AddListener(OnClickButtonPatisserie);

        // Attachement button pour vendre de cafe
        _cafeButtonVendeur.onClick.AddListener(OnClickButtonCafeVendeur);
        // Attachement button pour vendre de Th�
        _theButtonVendeur.onClick.AddListener(OnClickButtonTheVendeur);
        // Attachement button pour vendre de Jus
        _jusButtonVendeur.onClick.AddListener(OnClickButtonJusVendeur);
        // Attachement button pour vendre de Milkshake
        _MilkButtonVendeur.onClick.AddListener(OnClickButtonMilkVendeur);
        // Attachement button pour vendre de Patisserie
        _patisserieButtonVendeur.onClick.AddListener(OnClickButtonPatisserieVendeur);
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

    public void OnClickButtonCafeVendeur()
    {
        
        _idleModel.AddMoney(_idleModel.GetCafeIncome().GetValue());
    }

    public void OnClickButtonTheVendeur()
    {
       
        _idleModel.AddMoney(_idleModel.GetTheIncome().GetValue());
    }
    public void OnClickButtonMilkVendeur()
    {
        
        _idleModel.AddMoney(_idleModel.GetMilkIncome().GetValue());
    }

    public void OnClickButtonJusVendeur()
    {
      
        _idleModel.AddMoney(_idleModel.GetJusIncome().GetValue());
    }

    public void OnClickButtonPatisserieVendeur()
    {
       
        _idleModel.AddMoney(_idleModel.GetPatisserieIncome().GetValue());
    }
    public void OnClickPorte()
    {
        Debug.Log(_idleModel.GetMoney().GetValue());
            
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
    public void OnClickButtonCafe()
    {
        if (_idleModel.GetMoney().GetValue() >= _idleModel.GetCafePrixUp().GetValue())
        {
            _idleModel.UpgradeCafe();
        }
    }

    public void OnClickButtonThe()
    {
        if (_idleModel.GetThePrixUp().GetValue() <= _idleModel.GetMoney().GetValue())
        {
            _idleModel.UpgradeThe();
        }

    }

    public void OnClickButtonJus()
    {
        if (_idleModel.GetJusPrixUp().GetValue() <= _idleModel.GetMoney().GetValue())
        {
            _idleModel.UpgradeJus();
        }

    }

    public void OnClickButtonMilk()
    {
        if (_idleModel.GetMilkPrixUp().GetValue() <= _idleModel.GetMoney().GetValue())
        {
            _idleModel.UpgradeMilk();
        }

    }

    public void OnClickButtonPatisserie()
    {
        if (_idleModel.GetPatisseriePrixUp().GetValue() <= _idleModel.GetMoney().GetValue())
        {
            _idleModel.UpgradePatisserie();
        }

    }
}
