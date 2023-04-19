using System;
using System.Data;
using System.Net;

namespace MudrenokAPI.Services
{
    public class JewelryService
    {
        public static bool ValidateName(string name)
        {
            if (name == null) {
                throw new Exception($"name could't be NULL");
            }
            return true;
        }

        public static bool ValidateUrl (string url)
        {
            try
            {
                var request = WebRequest.Create(url);
                request.Method = "HEAD";

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                throw new Exception($"url: {url} dosen't exist");
            }
        }
    }
}
