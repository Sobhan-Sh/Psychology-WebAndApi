namespace PC.Utility;

public class SD
{
    public const string BaseUrlProject = "https://localhost:44321/";

    public class RoleName
    {
        public const int Admin_Id = 1;
        public const int Customer_Id = 2;
        public const int Patient_Id = 3;
        public const int Psychologist_Id = 4;

        public const string Admin = "AdminManagment";
        public const string Customer = "Customer";
        public const string Patient = "Patient";
        public const string Psychologist = "Psychologist";
    }

    public class UserName
    {
        public const string Admin = "Administrator@1402";
    }

    public class GenderName
    {
        public const int Man_Id = 1;
        public const int Lady_Id = 2;
        public const int Oder_Id = 3;

        public const string Man = "آقا";
        public const string Lady = "خانم";
        public const string Oder = "دیگر";
    }

    public class VerifyPayment
    {
        public const string Visit = "Payment/VerifyPaymentVisit";
    }
}