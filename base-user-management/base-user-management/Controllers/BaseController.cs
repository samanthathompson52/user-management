using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Text;

namespace base_user_management
{
    [ApiController]
    [Route("[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private string _PostBody = "";
        public string PostBody
        {
            get
            {
                if (_PostBody == "")
                {
                    _PostBody = "";

                    Request.EnableBuffering();
                    using (StreamReader sr = new StreamReader(Request.Body, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, bufferSize: 1024, leaveOpen: true))
                    {
                        _PostBody = sr.ReadToEnd();
                        Request.Body.Position = 0;
                    }
                }

                return _PostBody;
            }
        }

        [NonAction]
        public string GetAuthToken()
        {
            string headerString = Request.Headers["Authorization"];
            string authToken = "";

            if (string.IsNullOrEmpty(headerString) == false)
            {
                headerString = headerString.ToLower();
                if (headerString.Contains("bearer "))
                {
                    authToken = headerString.Replace("bearer ", "");
                }
            }
            return authToken;
        }

        [NonAction]
        public double GetFromQueryString(string keyName, double defaultValue)
        {
            string queryDouble = Request.Query[keyName];

            if (string.IsNullOrEmpty(queryDouble) == true)
            {
                return defaultValue;
            }

            double value;
            if (double.TryParse(queryDouble, out value) == false)
            {
                throw new Exception($"{keyName} is not a valid double.");
            }

            return value;
        }

        [NonAction]
        public DateTime GetFromQueryString(string keyName, DateTime defaultValue)
        {
            string queryDateTime = Request.Query[keyName];

            if (string.IsNullOrEmpty(queryDateTime) == true)
            {
                return defaultValue;
            }

            DateTime value;
            if (DateTime.TryParse(queryDateTime, out value) == false)
            {
                throw new Exception($"{keyName} is not a valid DateTime.");
            }

            return value;
        }

        [NonAction]
        public decimal GetFromQueryString(string keyName, decimal defaultValue)
        {
            string queryDecimal = Request.Query[keyName];

            if (string.IsNullOrEmpty(queryDecimal) == true)
            {
                return defaultValue;
            }

            decimal value;
            if (decimal.TryParse(queryDecimal, out value) == false)
            {
                throw new Exception($"{keyName} is not a valid decimal.");
            }

            return value;
        }

        [NonAction]
        public int GetFromQueryString(string keyName, int defaultValue)
        {
            string queryInt = Request.Query[keyName];

            if (string.IsNullOrEmpty(queryInt) == true)
            {
                return defaultValue;
            }

            int value;
            if (int.TryParse(queryInt, out value) == false)
            {
                throw new Exception($"{keyName} is not a valid integer.");
            }

            return value;
        }

        [NonAction]
        public string GetFromQueryString(string keyName, string defaultValue)
        {
            string queryString = Request.Query[keyName];

            if (string.IsNullOrEmpty(queryString) == true)
            {
                return defaultValue;
            }

            return queryString;
        }

        [NonAction]
        public string[] GetArrayFromQueryString(string keyName, StringValues defaultValue)
        {
            if (Request.Query.ContainsKey(keyName) == false)
            {
                return defaultValue;
            }

            StringValues queryValues = Request.Query[keyName];

            if (queryValues == StringValues.Empty)
            {
                return defaultValue;
            }

            return queryValues.ToArray();
        }
    }
}