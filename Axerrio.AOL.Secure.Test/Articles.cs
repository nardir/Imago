using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Axerrio.AOL.Secure.Test
{
    public class Articles
    {
        // The Client ID is used by the application to uniquely identify itself to Azure AD.
        // The Tenant is the name of the Azure AD tenant in which this application is registered.
        // The AAD Instance is the instance of Azure, for example public Azure or Azure China.
        // The Redirect URI is the URI where Azure AD will return OAuth responses.
        // The Authority is the sign-in URL of the tenant.
        //
        private static string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        private static string tenant = ConfigurationManager.AppSettings["ida:Tenant"];
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        static Uri redirectUri = new Uri(ConfigurationManager.AppSettings["ida:RedirectUri"]);

        private static string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        //
        // To authenticate to the To Do list service, the client needs to know the service's App ID URI.
        // To contact the To Do list service we need it's URL as well.
        //
        private static string ximagoResourceId = ConfigurationManager.AppSettings["ximago:ximagoResourceId"];
        private static string ximagoBaseAddress = ConfigurationManager.AppSettings["ximago:ximagoBaseAddress"];

        private HttpClient httpClient = new HttpClient();
        private AuthenticationContext authContext = null;



        public void CallArticle()
        {
            //
            // As the application starts, try to get an access token without prompting the user.  If one exists, populate the To Do list.  If not, continue.
            //
            authContext = new AuthenticationContext(authority, new FileCache());
            AuthenticationResult result = null;
            try
            {
                result = authContext.AcquireTokenAsync(ximagoResourceId, clientId, redirectUri,new AuthorizationParameters(PromptBehavior.Never, null)).Result;
                
                // A valid token is in the cache -
                // Once the token has been returned by ADAL, add it to the http authorization header, before making the call to access the To Do list service.
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);

                // Call the To Do list service.
                HttpResponseMessage response =httpClient.GetAsync(ximagoBaseAddress + "/api/v1/articles/A0030359").Result;

                if (response.IsSuccessStatusCode)
                {

                    // Read the response and databind to the GridView to display To Do items.
                    string s = response.Content.ReadAsStringAsync().Result;
                   
                }
                else
                {
                   Console.WriteLine("An error occurred : " + response.ReasonPhrase);
                }

            }
            catch (AdalException ex)
            {
                if (ex.ErrorCode == "user_interaction_required")
                {
                    // There are no tokens in the cache.  Proceed without calling the To Do list service.
                }
                else
                {
                    // An unexpected error occurred.
                    string message = ex.Message;
                    if (ex.InnerException != null)
                    {
                        message += "Inner Exception : " + ex.InnerException.Message;
                    }
                    Console.WriteLine(message);
                }
                return;
            }
        }

    }
}
