using System;
namespace DentalApps.Models
{
    public enum Status
    {
        Active = 0,
        InActive = 1,
        Blocked = 2
    }

    public enum Gender
    {
        Male = 0,
        Female = 1
    }

    public enum AppointmentStatus
    {
        Request = 0,
        Approve = 1,
        Canceled = 2
    }

    public enum Quadrant
    {
        I1=11,I2=12,I3=13,I4=14,I5=15,I6=16,I7=17,I8=18,
        II1=21,II2=22,II3=23,II4=24,II5=25,II6=26,II7=27,II8=28,
        III1=31,III2=32,III3=33,III4=34,III5=35,III6=36,III7=37,III8=38,
        IV1=41,IV2=42,IV3=43,IV4=44,IV5=45,IV6=46,IV7=47,IV8=48,
        V1=51,V2=52,V3=53,V4=54,V5=55,
        VI1=61,VI2=62,VI3=63,VI4=64,VI5=65,
        VII1=71,VII2=72,VII3=73,VII4=74,VII5=75,
        VIII1=81,VIII2=82,VIII383,VIII4=84,VIII5=85
    }
}

