using System;
using System.Collections.Generic;
using System.Text;

public class Gsm
{
    private string model;
    private string manufacturer;
    private decimal price;
    private string owner;
    private Battery battery;
    private Display display;
    private List<Call> callHistory;
    static Gsm iPhone4S = new Gsm("iPhone4S", "Apple", 400, "Ivan", new Battery(), new Display()); 

    public Gsm(string model, string manufactorer)
        : this(model, manufactorer, 0m)
    {
    }
    public Gsm(string model, string manufactorer, decimal price)
        : this(model, manufactorer, price, null)
    {
    }
    public Gsm(string model, string manufactorer, decimal price, string owner)
        : this(model, manufactorer, price, owner, null)
    {
    }
    public Gsm(string model, string manufactorer, decimal price, string owner, Battery battery)
        : this(model, manufactorer, price, owner, battery, null)
    {
    }

    public Gsm(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
    {
        //CheckStringFormat(model);
        this.model = model;
        //CheckStringFormat(manufacturer);
        this.manufacturer = manufacturer;
        //CheckPrice(price);
        this.owner = owner;
        //CheckStringFormat(owner);
        //CheckNameFormat(owner);
        this.battery = battery;
        this.display = display;
    }
    public string Model
    {
        get { return this.model; }
        set
        {
            CheckStringFormat(value);
            this.model = value;
        }

    }

    public string Manufacturer
    {
        get { return this.manufacturer; }
        set
        {
            CheckStringFormat(value);
            this.manufacturer = value;
        }

    }
    public decimal Price
    {
        get { return this.price; }
        set
        {
            CheckPrice(value);
        }

    }

    
    public string Owner
    {
        get { return this.owner; }
        set {
             CheckStringFormat(value);
             CheckNameFormat(value);
             this.owner = value; }

    }
    public Battery Battery
    {
        get { return this.battery; }
        set { this.battery = value; }

    }
    public Display Display
    {
        get { return this.display; }
        set { this.display = value; }

    }
   
    public static Gsm IPhone4S
    {
        get { return iPhone4S; }
    }
    public List<Call> CallHistory 
    {
        get { return this.callHistory; }
        set { this.callHistory = value; }

    }


    public override string ToString()
    {
        string printPrice = this.Price == 0 ? "[unspecified price]" : this.Price.ToString();
        string printOwner = this.Owner??"[unspecified owner]";
        string printBatteryModel = (this.Battery == null) || ((this.Battery == null)&&(this.Battery.Model==null)) ? "[unspecified battery model]" : this.Battery.Model;
        string printBatteryHourIdle = (this.Battery == null) || ((this.Battery != null)&&(this.Battery.HourIdle==0)) ? "[unspecified battery hours idle]" : this.Battery.HourIdle.ToString();
        string printBatteryHourTalk = (this.Battery == null) || ((this.Battery != null) && (this.Battery.HourTalk == 0)) ? "[unspecified battery hours talk]" : this.Battery.HourTalk.ToString();
        string printBatteryType = this.Battery== null ? "[unspecified battery type]" : this.Battery.Type.ToString();
        string printDisplaySize = (this.Display==null)||((this.Display!=null)&&(this.Display.Size==null))? "[unspecified display size]":this.Display.Size;
        string printDisplayNumberOfColors = (this.Display == null) || ((this.Display != null) && (this.Display.NumberOfColors==0)) ? "[unspecified number of colors]" : this.Display.NumberOfColors.ToString(); 
        

        return string.Format("Model: {0}, Manufacturer: {1}, Price: {2} EUR, Owner: {3}, Battery Model: {4}, Battery Hours Idle: {5} hours,"+
            " Battery Hours Talk: {6} hours, Batery Type: {7}, Display size: {8}, Display number of colors: {9}",
            this.Model, this.Manufacturer,printPrice, printOwner, printBatteryModel, printBatteryHourIdle, printBatteryHourTalk, printBatteryType, printDisplaySize, printDisplayNumberOfColors);
    }

   

    public  void CheckStringFormat(string value)
    {
        if((String.IsNullOrEmpty(value))||(String.IsNullOrEmpty(value.Trim())))
        {
            throw new ArgumentException("Name cannot be empty!");
        }
        if (value.Length < 2)
        {
            throw new ArgumentException("Name too short! It should be at least 2 letters");
        }
        if (value.Length >= 50)
        {
            throw new ArgumentException("Name too long! It should be less than 50 letters");
        }
       
        

    }

    public static void CheckNameFormat(string value)
    {
        foreach (char ch in value)
        {
            if (!IsLetterAllowedInNames(ch))
            {
                throw new ArgumentException("Invalid name! Use only letters, space and hyphen");
            }
        }
    }
    private static bool IsLetterAllowedInNames(char ch)
    {
        bool isAllowed =
            char.IsLetter(ch) || ch == '-' || ch == ' ';
        return isAllowed;
    }
    private void CheckPrice(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Price have to be bigger than 0!");
        }
        else this.price = value;
    }
    public static List<Call> AddCalls(List<Call>callHistory, Call call)
    {
        callHistory.Add(call);
        return callHistory;
    }
    public static List<Call> DeleteCalls(List<Call> callHistory, Call call)
    {
        callHistory.Remove(call);
        return callHistory;
    }
    public static List<Call> ClearCalls(List<Call> callHistory)
    {
        callHistory.Clear();
        return callHistory;
    }
    public static decimal TotalPrice(List<Call> callHistory, decimal pricePerMinute)
    {
        decimal totalPrice=0;
        for (int i = 0; i < callHistory.Count; i++)
			{
			 totalPrice+=(decimal)(((callHistory[i].DuratationInSeconds)/60)*pricePerMinute);
			}
        return totalPrice;
    }
}