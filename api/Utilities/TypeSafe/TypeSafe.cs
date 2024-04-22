namespace api.Models.TypeSafe;

public class TypeSafe
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Contributor = "Contributor";
    }

    public static class Controller
    {
        public const string Product = "Product";
        public const string ProductItem = "ProductItem";
        public const string PaymentType = "PaymentType";
        public const string ShippingMethod = "ShippingMethod";
        public const string OrderStatus = "OrderStatus";
        public const string UserPaymentMethod = "UserPaymentMethod";
    }

    public static class Permissions
    {
        public const int None = 0;
        public const int Read = 1;
        public const int Write = 2;
        public const int Update = 3;
        public const int Patch = 4;
        public const int Delete = 5;
        
        public static List<int> GetAdminPermissions()
        {
            return [ Read, Write, Update, Patch, Delete ];
        }
    }
    
    public static string[] GetAdminPermissions()
    {
        return new[]
        {
            Permissions.Read.ToString(),
            Permissions.Write.ToString(),
            Permissions.Update.ToString(),
            Permissions.Patch.ToString(),
            Permissions.Delete.ToString()
        };
    }

    public static class Policies
    {
        public const string PaymentTypePolicy = "PaymentTypePolicy";
        public const string ShippingMethodPolicy = "ShippingMethodPolicy";
        public const string OrderStatus = "OrderStatusPolicy";
        public const string UserPaymentMethod = "UserPaymentMethodPolicy";
        public const string ReadPolicy = "ReadPolicy";
        public const string ReadAndWritePolicy = "AddAndReadPolicy";
        public const string FullControlPolicy = "FullControlPolicy";

        public const string GenericPolicy = "GenericPolicy";
    }
    
    public static class Microsoft
    {
        public const string RolePath = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
    }
    
    public static class AuthorizationPayload
    {
        public const string Permissions = "Permissions";
    }
    
    public static class CookiesName
    {
        public static string Token = "Token";
    }
}