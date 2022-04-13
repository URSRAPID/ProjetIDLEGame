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
    [SerializeField] private GameObject _wayPointsClientSpecial;

    [SerializeField] VendeursView _spawnPointClient;
    [SerializeField] public GameObject _spawnPrefabClient;
    [SerializeField] public GameObject _spawnPrefabClientSpecial;

   

    private List<ClientMove> cafe;
    private List<ClientMove> the;
    private List<ClientMove> jus;
    private List<ClientMove> milk;
    private List<ClientMove> patisserie;

    private List<ClientSpecialMove> cafeSpecial;
    private List<ClientSpecialMove> theSpecial;
    private List<ClientSpecialMove> jusSpecial;
    private List<ClientSpecialMove> milkSpecial;
    private List<ClientSpecialMove> patisserieSpecial;


    [SerializeField] private FloatView _moneyView;
    [SerializeField] private FloatView CafeText;
    [SerializeField] private FloatView TheText;
    [SerializeField] private FloatView JusText;
    [SerializeField] private FloatView MilkshakeText;
    [SerializeField] private FloatView PatisserieText;



    [SerializeField] Button _cafeButtonObject;
    [SerializeField] Button _theButtonObject;
    [SerializeField] Button _jusButtonObject;
    [SerializeField] Button _MilkButtonObject;
    [SerializeField] Button _patisserieButtonObject;

    [SerializeField] Button _vitesseClientsButtonAmeloriation;
    [SerializeField] Button _pubButtonAmeloriation;
    [SerializeField] Button _chanceTipsButtonAmeloriation;
    [SerializeField] Button _prixDeBaseButtonAmeloriation;
    [SerializeField] Button _venteParClicButtonAmeloriation;

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

    [SerializeField] Waiting _cafeSpecialClientWaiting;
    [SerializeField] Waiting _theSpecialClientWaiting;
    [SerializeField] Waiting _jusSpecialClientWaiting;
    [SerializeField] Waiting _milkSpecialClientWaiting;
    [SerializeField] Waiting _patisserieSpecialClientWaiting;

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

        _vitesseClientsButtonAmeloriation.onClick.AddListener(OnClickAmeliorationVitesseClients);
        _pubButtonAmeloriation.onClick.AddListener(OnClikSpawnClientSpecial);
        _chanceTipsButtonAmeloriation.onClick.AddListener(OnClickAmeliorationchanceTips);
        _prixDeBaseButtonAmeloriation.onClick.AddListener(OnClickAmeliorationPrixDeBase);
        _venteParClicButtonAmeloriation.onClick.AddListener(OnClickAmeliorationVenteParClic);


        //Attachement button pour amélioration de price cafe 
        _cafeButtonObject.onClick.AddListener(OnClickButtonCafe);
        //Attachement button pour amélioration de price Thé
        _theButtonObject.onClick.AddListener(OnClickButtonThe);
        //Attachement button pour amélioration de price Jus
        _jusButtonObject.onClick.AddListener(OnClickButtonJus);
        //Attachement button pour amélioration de price Milkshake
        _MilkButtonObject.onClick.AddListener(OnClickButtonMilk);
        //Attachement button pour amélioration de price Patisserie 
        _patisserieButtonObject.onClick.AddListener(OnClickButtonPatisserie);

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
        _theWaiting.AddListener(OnClientEnterThe );
        _jusWaiting.AddListener(OnClientEnterJus );
        _milkWaiting.AddListener(OnClientEnterMilk );
        _patisserieWaiting.AddListener(OnClientEnterPatisserie );

        _cafeSpecialClientWaiting.AddListenerClientSpecial(OnClientSpecialEntreCafe);
        _theSpecialClientWaiting.AddListenerClientSpecial(OnClientSpecialEntreThe);
        _jusSpecialClientWaiting.AddListenerClientSpecial(OnClientSpecialEntreJus);
        _milkSpecialClientWaiting.AddListenerClientSpecial(OnClientSpecialEntreMilk);
        _patisserieSpecialClientWaiting.AddListenerClientSpecial(OnClientSpecialEntrePatisserie);

        cafe = new List<ClientMove>();
        the = new List<ClientMove>();
        jus = new List<ClientMove>();
        milk = new List<ClientMove>();
        patisserie = new List<ClientMove>();

        cafeSpecial = new List<ClientSpecialMove>();
        theSpecial = new List<ClientSpecialMove>();
        jusSpecial = new List<ClientSpecialMove>();
        milkSpecial = new List<ClientSpecialMove>();
        patisserieSpecial = new List<ClientSpecialMove>();

    }

    public void OnClickAmeliorationVenteParClic()
    {
        
    }

    public void OnClickAmeliorationPrixDeBase()
    {
        
    }

    public void OnClickAmeliorationchanceTips()
    {
        
    }

    public void OnClickAmeliorationVitesseClients()
    {
      
    }

    private void OnClikSpawnClient()
    {
        Vector2 whereToSpawn;
        whereToSpawn = new Vector2(_spawnPointClient.transform.position.x, _spawnPointClient.transform.position.y);
        GameObject client = Instantiate(_spawnPrefabClient, whereToSpawn, Quaternion.identity);
        client.GetComponent<ClientMove>().Init(_wayPointsToCafe, _wayPointsToThe, _wayPointsToJus, _wayPointsToMilk, _wayPointsToPatisserie);
    }

    private void OnClikSpawnClientSpecial()
    {
        Debug.Log("Merge");
        float spawnRate = 2f;
        float nextSpawn = 0.0f;
        Vector2 whereToSpawn;

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time * spawnRate;
            whereToSpawn = new Vector2(_spawnPointClient.transform.position.x, _spawnPointClient.transform.position.y);
            GameObject clientSpecial = Instantiate(_spawnPrefabClientSpecial, whereToSpawn, Quaternion.identity);
            clientSpecial.GetComponent<ClientSpecialMove>().Init(_wayPointsClientSpecial);
        }
       
    }
    

    private void OnClientEnterThe(ClientMove waypoints)
    {
        waypoints.stop = true;
        the.Add(waypoints);
        

    }
    private void OnClientSpecialEntreThe(ClientSpecialMove waypointsClientSpecial)
    {

        waypointsClientSpecial.stop = true;
        theSpecial.Add(waypointsClientSpecial);
    }

    private void OnClientEnterJus(ClientMove waypoints)
    {
        waypoints.stop = true;
        jus.Add(waypoints);
    }
    private void OnClientSpecialEntreJus(ClientSpecialMove waypointsClientSpecial)
    {
        waypointsClientSpecial.stop = true;
        jusSpecial.Add(waypointsClientSpecial);
    }

    private void OnClientEnterMilk(ClientMove waypoints)
    {
        waypoints.stop = true;
        milk.Add(waypoints);
    }

    private void OnClientSpecialEntreMilk(ClientSpecialMove waypointsClientSpecial)
    {
        waypointsClientSpecial.stop = true;
        milkSpecial.Add(waypointsClientSpecial);
    }

    private void OnClientEnterPatisserie(ClientMove waypoints)
    {
        waypoints.stop = true;
        patisserie.Add(waypoints);
    }

    private void OnClientSpecialEntrePatisserie(ClientSpecialMove waypointsClientSpecial)
    {
        waypointsClientSpecial.stop = true;
        patisserieSpecial.Add(waypointsClientSpecial);
    }


    public void OnClientEnterCafe(ClientMove waypoints)
    {
        waypoints.stop = true;
        cafe.Add(waypoints);
    }
    private void OnClientSpecialEntreCafe(ClientSpecialMove waypointsClientSpecial)
    {
        waypointsClientSpecial.stop = true;
        cafeSpecial.Add(waypointsClientSpecial);
    }


    public void OnClickButtonCafeVendeur()
    {
        if(cafeSpecial[0].stop == true  )
        {
            _idleModel.AddMoney(_idleModel.GetCafeIncome().GetValue());
            cafeSpecial[0].stop = false;
            cafeSpecial.RemoveAt(0);
        }
        else if (cafe[0].stop == true)
        {
            cafe[0].stop = false;
            cafe.RemoveAt(0);
        }
        
        
      
       


    }

    public void OnClickButtonTheVendeur()
    {
        if (the[0].stop == true  )
        {
            _idleModel.AddMoney(_idleModel.GetTheIncome().GetValue());
            the[0].stop = false;
            the.RemoveAt(0);
           
        }
        else if(theSpecial[0].stop == true)
        {
            theSpecial[0].stop = false;
            theSpecial.RemoveAt(0);
        }

    }
    public void OnClickButtonMilkVendeur()
    {
        if (milk[0].stop == true  )
        {
            _idleModel.AddMoney(_idleModel.GetMilkIncome().GetValue());
            milk[0].stop = false;
            milk.RemoveAt(0);
           
        }
        if (milkSpecial[0].stop == true)
        {
            milkSpecial[0].stop = false;
            milkSpecial.RemoveAt(0);
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
        if (jusSpecial[0].stop == true)
        {
            jusSpecial[0].stop = false;
            jusSpecial.RemoveAt(0);
        }

    }

    public void OnClickButtonPatisserieVendeur()
    {
        if (patisserie[0].stop == true  )
        {
            _idleModel.AddMoney(_idleModel.GetPatisserieIncome().GetValue());
            patisserie[0].stop = false;
            patisserie.RemoveAt(0);
            
        }
        if (patisserieSpecial[0].stop == true)
        {
            patisserieSpecial[0].stop = false;
            patisserieSpecial.RemoveAt(0);

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
