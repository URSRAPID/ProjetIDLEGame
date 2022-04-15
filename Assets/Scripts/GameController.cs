using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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



    private List<ClientMove> clientsInCafe;
    private List<ClientMove> clientsInthe;
    private List<ClientMove> clientsInjus;
    private List<ClientMove> clientsInmilk;
    private List<ClientMove> clientsInpatisserie;




    [SerializeField] private FloatView _moneyView;
    [SerializeField] private FloatView _cafeMoneyView;
    [SerializeField] private FloatView _theMoneyView;
    [SerializeField] private FloatView _jusMoneyView;
    [SerializeField] private FloatView _milkMoneyView;
    [SerializeField] private FloatView _patisserieMoneyView;
    [SerializeField] private FloatView CafeText;
    [SerializeField] private FloatView TheText;
    [SerializeField] private FloatView JusText;
    [SerializeField] private FloatView MilkshakeText;
    [SerializeField] private FloatView PatisserieText;
    [SerializeField] private FloatView speedButtonAmeliorationText;
    [SerializeField] private FloatView prixButtonAmeliorationX3Text;



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


    [SerializeField] Waiting _cafeWaitingTrigger;
    [SerializeField] Waiting _theWaitingTrigger;
    [SerializeField] Waiting _jusWaitingTrigger;
    [SerializeField] Waiting _milkWaitingTrigger;
    [SerializeField] Waiting _patisserieWaitingTrigger;

    


    [SerializeField] private ClientSpecialMove _changerSpeedClientSpecial;

    [SerializeField] private SpawnClientSpecial _spawnClientSpecial;

    [SerializeField] float _speedClientStandard;

    

    int chanceObtenirTips;
    int chanceDeVenteX2;
    bool OpenTips = false;
    bool OpenPrixDeBaseX3 = false;
    bool OpenVenteParClicX2 = false;






    /*
    public int autoClicksPerSecond;
    public int minimumClicksToUnlockUpgrade;
    */

    void Start()
    {

        _idleModel = new IdleModel();
        _idleModel.GetMoney().Subscribe(_moneyView);
        _idleModel.GetCafeIncome().Subscribe(_cafeMoneyView);
        _idleModel.GetTheIncome().Subscribe(_theMoneyView);
        _idleModel.GetJusIncome().Subscribe(_jusMoneyView);
        _idleModel.GetMilkIncome().Subscribe(_milkMoneyView);
        _idleModel.GetPatisserieIncome().Subscribe(_patisserieMoneyView);
        _idleModel.GetCafePrixUp().Subscribe(CafeText);
        _idleModel.GetThePrixUp().Subscribe(TheText);
        _idleModel.GetJusPrixUp().Subscribe(JusText);
        _idleModel.GetMilkPrixUp().Subscribe(MilkshakeText);
        _idleModel.GetPatisseriePrixUp().Subscribe(PatisserieText);
        _idleModel.GetSpeedPrixUpClients().Subscribe(speedButtonAmeliorationText);
        _idleModel.GetPrixButtonAmeliorationX3().Subscribe(prixButtonAmeliorationX3Text);
        _idleModel.GetIsClientSpecial().Subscribe(_spawnClientSpecial);

        _vitesseClientsButtonAmeloriation.onClick.AddListener(OnClickAmeliorationVitesseClients);
        _pubButtonAmeloriation.onClick.AddListener(OnClikSpawnClientSpecial);
        _chanceTipsButtonAmeloriation.onClick.AddListener(OnClickAmeliorationchanceTips);
        _prixDeBaseButtonAmeloriation.onClick.AddListener(OnClickAmeliorationPrixDeBase);
        _venteParClicButtonAmeloriation.onClick.AddListener(OnClickAmeliorationVenteParClic);


        //Attachement button pour Up de price cafe 
        _cafeButtonObject.onClick.AddListener(OnClickButtonCafe);
        //Attachement button pour Up de price Thé
        _theButtonObject.onClick.AddListener(OnClickButtonThe);
        //Attachement button pour Up de price Jus
        _jusButtonObject.onClick.AddListener(OnClickButtonJus);
        //Attachement button pour Up de price Milkshake
        _MilkButtonObject.onClick.AddListener(OnClickButtonMilk);
        //Attachement button pour Up de price Patisserie 
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



        _cafeWaitingTrigger.AddListener(OnClientEnterCafe);
        _theWaitingTrigger.AddListener(OnClientEnterThe);
        _jusWaitingTrigger.AddListener(OnClientEnterJus);
        _milkWaitingTrigger.AddListener(OnClientEnterMilk);
        _patisserieWaitingTrigger.AddListener(OnClientEnterPatisserie);



        clientsInCafe = new List<ClientMove>();
        clientsInthe = new List<ClientMove>();
        clientsInjus = new List<ClientMove>();
        clientsInmilk = new List<ClientMove>();
        clientsInpatisserie = new List<ClientMove>();

    }

    public void OnClickAmeliorationVenteParClic()
    {
        if (_idleModel.GetMoney().GetValue() >= _idleModel.GetPrixVenteParClic().GetValue())
        {
            OpenVenteParClicX2 = true;

        }
    }

    public void OnClickAmeliorationPrixDeBase()
    {
        if (_idleModel.GetMoney().GetValue() >= _idleModel.GetPrixButtonAmeliorationX3().GetValue())
        {
            _idleModel.AddMoney(-_idleModel.GetPrixButtonAmeliorationX3().GetValue());
            OpenPrixDeBaseX3 = true;
            if (OpenPrixDeBaseX3 == true)
            {
                _idleModel.AddCafeIcome(2 * _idleModel.GetCafeIncome().GetValue());

                _idleModel.AddTheIcome(2 * _idleModel.GetTheIncome().GetValue());

                _idleModel.AddJusIcome(2 * _idleModel.GetJusIncome().GetValue());

                _idleModel.AddMilkIcome(2 * _idleModel.GetMilkIncome().GetValue());

                _idleModel.AddPatisserieIcome(2 * _idleModel.GetPatisserieIncome().GetValue());

                _idleModel.UpgradePrixAmeliorationX3();


            }
        }
    }

    public void OnClickAmeliorationchanceTips()
    {
        if (_idleModel.GetMoney().GetValue() >= _idleModel.GetPrixButtonAmeliorationTips().GetValue())
        {
            _idleModel.AddMoney(-_idleModel.GetPrixButtonAmeliorationTips().GetValue());
            OpenTips = true;
        }

    }

    public void OnClickAmeliorationVitesseClients()
    {
        if (_idleModel.GetMoney().GetValue() >= _idleModel.GetSpeedPrixUpClients().GetValue())
        {
            _speedClientStandard += 0.15f * _speedClientStandard;
            _idleModel.UpgradePrixSpeedClient();
        }

    }

    private void OnClikSpawnClient()
    {

       
        Vector2 whereToSpawn;
        whereToSpawn = new Vector2(_spawnPointClient.transform.position.x, _spawnPointClient.transform.position.y);
        GameObject client = Instantiate(_spawnPrefabClient, whereToSpawn, Quaternion.identity);
        client.GetComponent<ClientMoveStandard>().Init(_speedClientStandard, _wayPointsToCafe, _wayPointsToThe, _wayPointsToJus, _wayPointsToMilk, _wayPointsToPatisserie);
    }

    private void OnClikSpawnClientSpecial()
    {
        if (_idleModel.GetMoney().GetValue() >= _idleModel.GetPrixClientSpecial().GetValue())
        {
            _idleModel.GetIsClientSpecial().SetValue(true);
           
            _idleModel.AddMoney(-_idleModel.GetPrixClientSpecial().GetValue());
        }


    }


    private void OnClientEnterThe(ClientMove client)
    {
        client.Stop();
        clientsInthe.Add(client);


    }


    private void OnClientEnterJus(ClientMove client)
    {
        client.Stop();
        clientsInjus.Add(client);
    }


    private void OnClientEnterMilk(ClientMove client)
    {
        client.Stop();
        clientsInmilk.Add(client);
    }


    private void OnClientEnterPatisserie(ClientMove client)
    {
        client.Stop();
        clientsInpatisserie.Add(client);
    }



    public void OnClientEnterCafe(ClientMove client)
    {
        client.Stop();
        clientsInCafe.Add(client);
    }



    public void OnClickButtonCafeVendeur()
    {
        if (clientsInCafe.Count > 0)
        {
            if (clientsInCafe[0].stop == true)
            {
                
                _idleModel.AddMoney(_idleModel.GetCafeIncome().GetValue());
                clientsInCafe[0].Start();
                clientsInCafe.RemoveAt(0);

                if (OpenTips == true)
                {
                    chanceObtenirTips = Random.Range(0, 3);
                    if (chanceObtenirTips == 2)
                    {
                        _idleModel.AddMoney(_idleModel.GetCafeIncome().GetValue() / 3f);
                    }
                    Debug.Log(_idleModel.GetTips().GetValue() + "Wow");
                }
                if (OpenVenteParClicX2 == true)
                {
                    chanceDeVenteX2 = Random.Range(0, 6);
                    if (chanceDeVenteX2 == 6)
                    {
                        _idleModel.AddMoney(_idleModel.GetCafeIncome().GetValue() * 2);
                    }
                }


            }
        }



    }



    public void OnClickButtonTheVendeur()
    {
        if (clientsInthe[0].stop == true)
        {
            _idleModel.AddMoney(_idleModel.GetTheIncome().GetValue());
           
            clientsInthe[0].Start();
            clientsInthe.RemoveAt(0);

            if (OpenTips == true)
            {
                Debug.Log(chanceObtenirTips);
                chanceObtenirTips = Random.Range(0, 3);
                if (chanceObtenirTips == 2)
                {
                    _idleModel.AddMoney(_idleModel.GetTheIncome().GetValue() / 3f);
                }
            }
            if (OpenVenteParClicX2 == true)
            {
                chanceDeVenteX2 = Random.Range(0, 6);
                if (chanceDeVenteX2 == 6)
                {
                    _idleModel.AddMoney(_idleModel.GetTheIncome().GetValue() * 2);
                }
            }


        }
    }
    public void OnClickButtonMilkVendeur()
    {
        if (clientsInmilk[0].stop == true)
        {
            _idleModel.AddMoney(_idleModel.GetMilkIncome().GetValue());
           
            clientsInmilk[0].Start();
            clientsInmilk.RemoveAt(0);


            if (OpenTips == true)
            {
                Debug.Log(chanceObtenirTips);
                chanceObtenirTips = Random.Range(0, 3);
                if (chanceObtenirTips == 2)
                {
                    _idleModel.AddMoney(_idleModel.GetMilkIncome().GetValue() / 3f);
                }
            }
            if (OpenVenteParClicX2 == true)
            {
                chanceDeVenteX2 = Random.Range(0, 6);
                if (chanceDeVenteX2 == 6)
                {
                    _idleModel.AddMoney(_idleModel.GetMilkIncome().GetValue() * 2);
                }
            }

        }


    }

    public void OnClickButtonJusVendeur()
    {
        if (clientsInjus[0].stop == true)
        {
            _idleModel.AddMoney(_idleModel.GetJusIncome().GetValue());
            
            clientsInjus[0].Start();
            clientsInjus.RemoveAt(0);



            if (OpenTips == true)
            {
                Debug.Log(chanceObtenirTips);
                chanceObtenirTips = Random.Range(0, 3);
                if (chanceObtenirTips == 2)
                {
                    _idleModel.AddMoney(_idleModel.GetJusIncome().GetValue() / 3f);
                }
            }
            if (OpenVenteParClicX2 == true)
            {
                chanceDeVenteX2 = Random.Range(0, 6);
                if (chanceDeVenteX2 == 6)
                {
                    _idleModel.AddMoney(_idleModel.GetJusIncome().GetValue() * 2);
                }
            }
        }
    }

    public void OnClickButtonPatisserieVendeur()
    {
        if (clientsInpatisserie[0].stop == true)
        {
            
            _idleModel.AddMoney(_idleModel.GetPatisserieIncome().GetValue());
            clientsInpatisserie[0].Start();
            clientsInpatisserie.RemoveAt(0);



            if (OpenTips == true)
            {
                Debug.Log(chanceObtenirTips);
                chanceObtenirTips = Random.Range(0, 3);
                if (chanceObtenirTips == 2)
                {
                    _idleModel.AddMoney(_idleModel.GetPatisserieIncome().GetValue() / 3f);
                }
            }
            if (OpenVenteParClicX2 == true)
            {
                chanceDeVenteX2 = Random.Range(0, 6);
                if (chanceDeVenteX2 == 6)
                {
                    _idleModel.AddMoney(_idleModel.GetPatisserieIncome().GetValue() * 2);
                }
            }
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
