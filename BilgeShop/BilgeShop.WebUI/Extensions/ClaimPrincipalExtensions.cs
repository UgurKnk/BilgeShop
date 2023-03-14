using BilgeShop.Data.Enums;
using System.Security.Claims;

namespace BilgeShop.WebUI.Extensions
{

    // Cookie'de tutulan verilerin kontrollerini yapmak için yazılacak metotları bu class içerisinde topluyorum.
    public static class ClaimPrincipalExtensions
    {
        // this -> bu sayede metot artık sondan çağırılır.
        // user.GetUserId() gibi...
        public static int GetUserId(this ClaimsPrincipal user)
        {
            return Convert.ToInt32(user.Claims.FirstOrDefault(x => x.Type == "id")?.Value);

            //Soru işareti koymazsak, olmayan bir kayıdın value'sunu almaya kalkarken patlar. Ben bunu mümkün olduğunu, sorun olmadığını belirtiyorum.
        }

        public static string GetUserFirstName(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(x => x.Type == "firstName")?.Value;
        }

        public static string GetUserLastName(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(x => x.Type == "lastName")?.Value;
        }
        public static string GetUserEmail(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(x => x.Type == "email")?.Value;
        }
        public static bool IsLogged(this ClaimsPrincipal user)
        {
            if (user.Claims.FirstOrDefault(x => x.Type == "id") != null)
                return true;
            else
                return false;
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            if (user.Claims.FirstOrDefault(x => x.Type == "userType")?.Value == UserTypeEnum.Admin.ToString())
                return true;
            else
                return false;


        }
    }
}

