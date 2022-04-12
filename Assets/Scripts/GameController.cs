using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private IdleModel _idleModel;

    [SerializeField] private GameObject _wayPointsToCafe;
    [SerializeField] private GameObject _wayPointsToThe;
    [SerializeField] private GameObject _wayPointsToJus;
    [SerializeField] private GameObject _wayPointsToMilk;
    [SerializeField] private GameObject _wayPointsToPatisserie;

    [SerializeField] VendeursView _spawnPointClient;
    [SerializeField] public GameObject _spawnPrefab;


    private List<Waypoints> cafe;
    private List<Waypoints> the;
    private List<Waypoints> jus;
    private List<Waypoints> milk;
    private List<Waypoints> patisserie;


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

        _spawnPointClient.AddListener(OnClikSpawnClient);


        _cafeWaiting.AddListener(OnClientEnterCafe);
        _theWaiting.AddListener(OnClientEnterThe);
        _jusWaiting.AddListener(OnClientEnterJus);
        _milkWaiting.AddListener(OnClientEnterMilk);
        _patisserieWaiting.AddListener(OnClientEnterPatisserie);

        cafe = new List<Waypoints>();
        the = new List<Waypoints>();
        jus = new List<Waypoints>();
        milk = new List<Waypoints>();
        patisserie = new List<Waypoints>();

    }

    private void OnClikSpawnClient()
    {
        Vector2 whereToSpawn;
        whereToSpawn = new Vector2(_spawnPointClient.transform.position.x, _spawnPointClient.transform.position.y);
        GameObject client = Instantiate(_spawnPrefab, whereToSpawn, Quaternion.identity);
        client.GetComponent<Waypoints>().Init(_wayPointsToCafe, _wayPointsToThe, _wayPointsToJus, _wayPointsToMilk, _wayPointsToPatisserie);
    }

    private void OnClientEnterThe(Waypoints waypoints)
    {
        waypoints.stop = true;
        the.Add(waypoints);

    }

    private void OnClientEnterJus(Waypoints waypoints)
    {
        waypoints.stop = true;
        jus.Add(waypoints);
    }

    private void OnClientEnterMilk(Waypoints waypoints)
    {
        waypoints.stop = true;
        milk.Add(waypoints);
    }

    private void OnClientEnterPatisserie(Waypoints waypoints)
    {
        waypoints.stop = true;
        patisserie.Add(waypoints);
    }


    public void OnClientEnterCafe(Waypoints waypoints)
    {
        waypoints.stop = true;
        cafe.Add(waypoints);
    }


    public void OnClickButtonCafeVendeur()
    {
        if (cafe[0].stop == true)
        {
            _idleModel.AddMoney(_idleModel.GetCafeIncome().GetValue());
            cafe[0].stop = false;
            cafe.RemoveAt(0);
        }


    }

    public void OnClickButtonTheVendeur()
    {
        if (the[0].stop == true)
        {
            _idleModel.AddMoney(_idleModel.GetTheIncome().GetValue());
            the[0].stop = false;
            the.RemoveAt(0);
        }

    }
    public void OnClickButtonMilkVendeur()
    {
        if (milk[0].stop == true)
        {
            _idleModel.AddMoney(_idleModel.GetMilkIncome().GetValue());
            milk[0].stop = false;
            milk.RemoveAt(0);
        }

    }

    public void OnClickButtonJusVendeur()
    {
        if (jus[0].stop == true)
        {
            _idleModel.AddMoney(_idleModel.GetJusIncome().GetValue());
            jus[0].stop = false;
            jus.RemoveAt(0);
        }

    }

    public void OnClickButtonPatisserieVendeur()
    {
        if(patisserie[0].stop == true)
        {
            _idleModel.AddMoney(_idleModel.GetPatisserieIncome().GetValue());
            patisserie[0].stop = false;
            patisserie.RemoveAt(0);
        }
        
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
