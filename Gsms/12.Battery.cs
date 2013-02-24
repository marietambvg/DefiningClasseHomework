using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public enum BatteryType {LiIon, NiMH, NiCd }

public class Battery
{
    private string model;
    private int hourIdle;
    private int hourTalk;
    private BatteryType type;

    public Battery()
    {
        this.model =null; 
        this.hourIdle = 0;
        this.hourTalk = 0;
        this.type=BatteryType.LiIon;
             
    }

    public Battery(string model, int hourIdle, int hourTalk, BatteryType type)
    {
        this.model = model;
        this.hourIdle = hourIdle;
        this.hourTalk = hourTalk;
        this.type = type;
           }
    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }
    public int HourIdle
    {
        get { return this.hourIdle; }
        set { this.hourIdle = value; }
    }
    public int HourTalk
    {
        get { return this.hourTalk; }
        set { this.hourTalk = value; }
    }
    public BatteryType Type
    {
        get { return this.type; }
        set {
            switch (value)
            {
                case BatteryType.LiIon: break;
                case BatteryType.NiMH: break;
                case BatteryType.NiCd: break;
                default:
                throw new ArgumentException("Unallowed Battery Type!");
                     
            }
            this.type = value; }          
            
    }

}
