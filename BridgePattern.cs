namespace BridgePattern {
      public abstract class MovieLicense
      {
      private readonly Discount _discount { get; }
            public string Movie { get; }
            public DateTime PurchaseTime { get; }
                    protected MovieLicense(string movie, DateTime purchaseTime, Discount discount)        {
                  Movie = movie;
                  PurchaseTime = purchaseTime;
                  _discount = discount;
             
    }
            public abstract decimal GetCorePrice();
            public abstract DateTime ? GetExpirationDate();
       
  }
      public class TwoDaysLicense : MovieLicense    {
            public TwoDaysLicense(string movie,
                                  DateTime purchaseTime,
                                  Discount discount)           
        : base(movie, purchaseTime, discount)        {
             
    }
            public decimal GetPrice() =>
        GetCorePrice * (1 - discount / 100)        public override decimal
        GetCorePrice() => 4;
            public override DateTime? GetExpirationDate() =>
        PurchaseTime.AddDays(2);
       
  }
      public class LifeLongLicense : MovieLicense    {
            public LifeLongLicense(string movie,
                                   DateTime purchaseTimeDiscount discount)           
        : base(movie, purchaseTime, discount)        {
             
    }
            public override decimal GetCorePrice() => 8;
            public override DateTime? GetExpirationDate() => null;
       
  }
    public abstract class Discount { public abstract int GetDiscount(); }
  public class NoDiscount : Discount {
        public int GetDiscount() => 0;
  }
  public class MilitaryDiscount : Discount {
        public int GetDiscount() => 10;
  }
  public class SeniorDiscount : Discount {
        public int GetDiscount() => 20;
  }  // showing one such concrete class if bridge pattern was not used/*public
     // class MilitaryTwoDaysLicense{      public MilitaryTwoDaysLicense(string
     // movie,DateTime purchaseTime, Discount
     // discount):base(movie,purchaseTime,discount)     {    }    public
     // GetCorePrice=> 4;    multiplier=1-(10/100);    public GetPrice()    {   
     //     return GetPriceCore*multiplier;    }}*///client code needs to be
     // modified     public class Program {     public static void Main()     { 
     //        DateTime now = DateTime.Now;         var license1 = new
     // TwoDaysLicense("Secret Life of Pets", now);         var license2 = new
     // LifeLongLicense("Matrix", now);         PrintLicenseDetails(license1); 
     //        PrintLicenseDetails(license2);         Console.ReadKey();     } 
     //    private static void PrintLicenseDetails(MovieLicense license)     { 
     //        Console.WriteLine($"Movie: {license.Movie}");       
     //  Console.WriteLine($"Price: {GetPrice(license)}");       
     //  Console.WriteLine($"Valid for: {GetValidFor(license)}");       
     //  Console.WriteLine();     }     private static string
     // GetPrice(MovieLicense license)     {         return
     // $"${license.GetPrice():0.00}";     }     private static string
     // GetValidFor(MovieLicense license)     {         DateTime? expirationDate
     // = license.GetExpirationDate();         if (expirationDate == null)     
     //        return "Forever";         TimeSpan timeSpan =
     // expirationDate.Value - DateTime.Now;         return $"{timeSpan.Days}d
     // {timeSpan.Hours}h {timeSpan.Minutes}m";     } }}