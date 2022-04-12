using System;

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

    public IdleModel()
    {
        cafeIncome = new FloatObservable(5);
        theIncome = new FloatObservable(50);
        jusIncome = new FloatObservable(100);
        milkIncome = new FloatObservable(150);
        patisserieIncome = new FloatObservable(300);
        cafePrixUp = new FloatObservable(10);
        thePrixUp = new FloatObservable(100);
        jusPrixUp = new FloatObservable(200);
        milkPrixUp = new FloatObservable(300);
        patisseriePrixUp = new FloatObservable(400);
        money = new FloatObservable(0);


    }
    public void UpgradeCafe()
    {
        AddMoney(-cafePrixUp.GetValue());
        cafePrixUp.Add(0.2f * cafePrixUp.GetValue());
        cafeIncome.Add(0.2f * cafeIncome.GetValue());
    }
    internal void UpgradeThe()
    {
        AddMoney(-thePrixUp.GetValue());
        thePrixUp.Add(0.2f * thePrixUp.GetValue());
        theIncome.Add(0.2f * theIncome.GetValue());
    }

    internal void UpgradePatisserie()
    {
        AddMoney(-patisseriePrixUp.GetValue());
        patisseriePrixUp.Add(0.2f * patisseriePrixUp.GetValue());
        patisserieIncome.Add(0.2f * patisserieIncome.GetValue());
    }

    internal void UpgradeMilk()
    {
        AddMoney(-milkPrixUp.GetValue());
        milkPrixUp.Add(0.2f * milkPrixUp.GetValue());
        milkIncome.Add(0.2f * milkIncome.GetValue());
        
    }
    internal void UpgradeJus()
    {
        AddMoney(-jusPrixUp.GetValue());
        jusPrixUp.Add(0.2f * jusPrixUp.GetValue());
        jusIncome.Add(0.2f * jusIncome.GetValue());

    }
    public void AddCafePrix(float deltaPrixCafe)
    {
        cafePrixUp.Add(deltaPrixCafe);
    }
    public void AddThePrix(float deltaPrixThe)
    {
        thePrixUp.Add(deltaPrixThe);
    }
    public void AddJusPrix(float deltaPrixJus)
    {
        jusPrixUp.Add(deltaPrixJus);
    }
    public void AddMilkPrix(float deltaPrixMilk)
    {
        cafePrixUp.Add(deltaPrixMilk);
    }
    public void AddPatisseriePrix(float deltaPrixPatisserie)
    {
        patisseriePrixUp.Add(deltaPrixPatisserie);
    }
    public void AddMoney(float deltaMoney)
    {
        money.Add(deltaMoney);
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


    public FloatObservable GetMoney()
    {
        return money;
    }


}
