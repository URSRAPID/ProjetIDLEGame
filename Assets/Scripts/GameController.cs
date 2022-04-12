using System;
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

    

    [SerializeField] VendeursView _vendeursCafe;
    [SerializeField] VendeursView _vendeursThe;
    [SerializeField] VendeursView _vendeursJus;
    [SerializeField] VendeursView _vendeursMilk;
    [SerializeField] VendeursView _vendeursPatisserie;


    [SerializeField] Waiting _cafeWaiting;
    [SerializeField] Waiting _theWaiting;
    [SerializeField] Waiting _jusWaiting;
    [SerializeField] Waiting _milkWaiting;
    [SerializeField] Waiting _patisserieWaiting;

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


        //Attachement button pour amélioration des 5 objects

            //Attachement button pour amélioration de price cafe 
            _cafeButtonAmelioration.onClick.AddListener(OnClickButtonCafe);
            //Attachement button pour amélioration de price Thé
            _theButtonAmelioration.onClick.AddListener(OnClickButtonThe);
            //Attachement button pour amélioration de price Jus
            _jusButtonAmelioration.onClick.AddListener(OnClickButtonJus);
            //Attachement button pour amélioration de price Milkshake
            _MilkButtonAmelioration.onClick.AddListener(OnClickButtonMilk);
            //Attachement button pour amélioration de price Patisserie 
            _patisserieButtonAmelioration.onClick.AddListener(OnClickButtonPatisserie);

        // Attachement button pour vendre de cafe
        _vendeursCafe.AddListener(OnClickButtonCafeVendeur);
        // Attachement button pour vendre de Thé
        _vendeursThe.AddListener(OnClickButtonTheVendeur);
         // Attachement button pour vendre de Jus
         _vendeursJus.AddListener(OnClickButtonJusVendeur);
         // Attachement button pour vendre de Milkshake
         _vendeursMilk.AddListener(OnClickButtonMilkVendeur);
         // Attachement button pour vendre de Patisserie
         _vendeursPatisserie.AddListener(OnClickButtonPatisserieVendeur);

        
        _cafeWaiting.AddListener(OnClientEnterCafe);
        _theWaiting.AddListener(OnClientEnterThe);
        _jusWaiting.AddListener(OnClientEnterJus);
        _milkWaiting.AddListener(OnClientEnterMilk);
        _patisserieWaiting.AddListener(OnClientEnterPatisserie);


    }

    private void OnClientEnterThe(Waypoints waypoints)
    {
        waypoints.stop = true;
    }

    private void OnClientEnterJus(Waypoints waypoints)
    {
        waypoints.stop = true;
    }

    private void OnClientEnterMilk(Waypoints waypoints)
    {
        waypoints.stop = true;
    }

    private void OnClientEnterPatisserie(Waypoints waypoints)
    {
        waypoints.stop = true;
    }

    
    public void OnClientEnterCafe(Waypoints waypoints)
    {
        waypoints.stop = true;
    }

    public void OnClientSorteCafe(Waypoints waypoints)
    {
        waypoints.stop = false;
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
