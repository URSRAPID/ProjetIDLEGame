using System;
using UnityEngine;

public class IdleModel
{
    private FloatObservable cafeIncome;
    private FloatObservable cafePrixUp;
    private FloatObservable thePrixUp;
    private FloatObservable theIncome;
    private FloatObservable jusPrixUp;
    private FloatObservable jusIncome;
    private FloatObservable milkPrixUp;
    private FloatObservable milkIncome;
    private FloatObservable patisseriePrixUp;
    private FloatObservable patisserieIncome;
    private FloatObservable money;
    private FloatObservable tips;
    private FloatObservable prixButtonAmeliorationTips;
    private FloatObservable prixButtonAmeliorationX3;
    private FloatObservable speedPrixUpClients;
    private FloatObservable prixVenteParClic;
    private FloatObservable prixClientSpecial;
    private BoolObservable isClientSpecial;

    public IdleModel()
    {
        cafeIncome = new FloatObservable(1) ;
        theIncome = new FloatObservable(2);
        jusIncome = new FloatObservable(3);
        milkIncome = new FloatObservable(4);
        patisserieIncome = new FloatObservable(5);
        cafePrixUp = new FloatObservable(150);
        thePrixUp = new FloatObservable(300);
        jusPrixUp = new FloatObservable(450);
        milkPrixUp = new FloatObservable(600);
        patisseriePrixUp = new FloatObservable(750);
        money = new FloatObservable(0);
        tips = new FloatObservable(0);
        prixButtonAmeliorationTips = new FloatObservable(1200);
        prixButtonAmeliorationX3 = new FloatObservable(500);
        speedPrixUpClients = new FloatObservable(250);
        prixVenteParClic = new FloatObservable(1000);
        prixClientSpecial = new FloatObservable(1500);
        isClientSpecial = new BoolObservable(false);
        
    }




    public void UpgradePrixAmeliorationX3()
    {
        prixButtonAmeliorationX3.Add(0.5f * prixButtonAmeliorationX3.GetValue());
    }

    public void UpgradePrixSpeedClient()
    {
        AddMoney(-GetSpeedPrixUpClients().GetValue());
        speedPrixUpClients.Add(0.2f * speedPrixUpClients.GetValue());
    }

    public void tipsValue()
    {
        Debug.Log(cafeIncome.GetValue());
        cafeIncome.Add(cafeIncome.GetValue() / 0.15f) ;
        AddMoney(tips.GetValue());
    }
    public void UpgradeCafe()
    {
        AddMoney(-cafePrixUp.GetValue());
        cafePrixUp.Add(0.4f * cafePrixUp.GetValue());
        cafeIncome.Add(0.3f * cafeIncome.GetValue());
    }
    internal void UpgradeThe()
    {
        AddMoney(-thePrixUp.GetValue());
        thePrixUp.Add(0.4f * thePrixUp.GetValue());
        theIncome.Add(0.25f * theIncome.GetValue());
    }

    internal void UpgradePatisserie()
    {
        AddMoney(-patisseriePrixUp.GetValue());
        patisseriePrixUp.Add(0.4f * patisseriePrixUp.GetValue());
        patisserieIncome.Add(0.1f * patisserieIncome.GetValue());
    }

    internal void UpgradeMilk()
    {
        AddMoney(-milkPrixUp.GetValue());
        milkPrixUp.Add(0.4f * milkPrixUp.GetValue());
        milkIncome.Add(0.15f * milkIncome.GetValue());
        
    }
    internal void UpgradeJus()
    {
        AddMoney(-jusPrixUp.GetValue());
        jusPrixUp.Add(0.4f * jusPrixUp.GetValue());
        jusIncome.Add(0.2f * jusIncome.GetValue());

    }






    public void AddPrixVenteParClic(float deltaPrixVenteParClic)
    {
        prixVenteParClic.Add(deltaPrixVenteParClic);
    }

    public void AddSpeedPrixUpClients(float deltaSpeedPrixUpClients)
    {
        speedPrixUpClients.Add(deltaSpeedPrixUpClients);
    }
    public void AddPrixButtonAmeliorationX3(float deltaPrixButtonAmeliorationX3)
    {
        prixButtonAmeliorationX3.Add(deltaPrixButtonAmeliorationX3);
    }
    public void AddPrixButtonAmeliorationTips(float deltaPrixAmeliorationTips)
    {
        prixButtonAmeliorationTips.Add(deltaPrixAmeliorationTips);
    }
    public void AddCafePrix(float deltaPrixCafe)
    {
        cafePrixUp.Add(deltaPrixCafe);
    }
    public void AddCafeIcome(float deltaPrixCafe)
    {
        cafeIncome.Add(deltaPrixCafe);
    }
    public void AddThePrix(float deltaPrixThe)
    {
        thePrixUp.Add(deltaPrixThe);
    }
    public void AddTheIcome(float deltaPrixThe)
    {
        theIncome.Add(deltaPrixThe);
    }
    public void AddJusPrix(float deltaPrixJus)
    {
        jusPrixUp.Add(deltaPrixJus);
    }
    public void AddJusIcome(float deltaPrixJus)
    {
        jusIncome.Add(deltaPrixJus);
    }
    public void AddMilkPrix(float deltaPrixMilk)
    {
        cafePrixUp.Add(deltaPrixMilk);
    }
    public void AddMilkIcome(float deltaPrixMilk)
    {
        milkIncome.Add(deltaPrixMilk);
    }
    public void AddPatisseriePrix(float deltaPrixPatisserie)
    {
        patisseriePrixUp.Add(deltaPrixPatisserie);
    }
    public void AddPatisserieIcome(float deltaPrixPatisserie)
    {
        patisserieIncome.Add(deltaPrixPatisserie);
    }
    public void AddMoney(float deltaMoney)
    {
        money.Add(deltaMoney);
    }






    internal FloatObservable GetPrixClientSpecial()
    {
        return prixClientSpecial;
    }
    internal FloatObservable GetPrixVenteParClic()
    {
        return prixVenteParClic;
    }

    internal FloatObservable GetSpeedPrixUpClients()
    {
        return speedPrixUpClients;
    }
    internal FloatObservable GetPrixButtonAmeliorationX3()
    {
        return prixButtonAmeliorationX3;
    }
    internal FloatObservable GetPrixButtonAmeliorationTips()
    {
        return prixButtonAmeliorationTips;
    }

    internal BoolObservable GetIsClientSpecial()
    {
        return isClientSpecial;
    }

    internal FloatObservable GetCafeIncome()
    {
        return cafeIncome;
    }

    public FloatObservable GetCafePrixUp()
    {
        return cafePrixUp;
    }
    public FloatObservable GetThePrixUp()
    {
        return thePrixUp;
    }
    internal FloatObservable GetTheIncome()
    {
        return theIncome;
    }

    public FloatObservable GetJusPrixUp()
    {
        return jusPrixUp;
    }
    internal FloatObservable GetJusIncome()
    {
        return jusIncome;
    }

    public FloatObservable GetMilkPrixUp()
    {
        return milkPrixUp;
    }
    internal FloatObservable GetMilkIncome()
    {
        return milkIncome;
    }

    public FloatObservable GetPatisseriePrixUp()
    {
        return patisseriePrixUp;
    }
    internal FloatObservable GetPatisserieIncome()
    {
        return patisserieIncome;
    }

    internal FloatObservable GetTips()
    {
        return tips;
    }

    public FloatObservable GetMoney()
    {
        return money;
    }


}
