using System;
using System.Collections.Generic;

using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using static PathOfServant.Form1;
using System.Web.Script.Serialization;
using System.Drawing;

namespace PathOfServant
{
    class WebTools
    {
        public class StashInfo
        {
            public string n { get; set; }
            public string i { get; set; }
            public string type { get; set; }
        }
        public static Dictionary<string,string> GetTypesOfStash()
        {
            string json = WebTools.getPrivateStashJSON("8dcfe28b4cd5d1ca884e2f2d539f8057", "https://pathofexile.com/character-window/get-stash-items?league=bestiary&tabs=1&tabIndex=1&accountName=piotrek816");
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            jsonSerializer.MaxJsonLength = Int32.MaxValue;
            List<StashInfo> ro = jsonSerializer.Deserialize<List<StashInfo>>(json);

            return new Dictionary<string, string>();
        }

        public static List<StashItemsFiltered> GetStashItemsFromWeb(string acc, string stashNo)
        {
            string url = "https://pathofexile.com/character-window/get-stash-items?league=bestiary&tabs=0&tabIndex="+stashNo+"&accountName=" + acc;
            IEnumerable<Tuple<string, string>> results = WebTools.ReadCookies(".pathofexile.com");
            Tuple<string, string> result = results.Where(x => x.Item1 == "POESESSID").First();

            string json = WebTools.getPrivateStashJSON(result.Item2, url);
            //do to: read cookie expiration date, read new cookie only when expired.

            //string json = WebTools.getPrivateStashJSON("8dcfe28b4cd5d1ca884e2f2d539f8057", url);

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            jsonSerializer.MaxJsonLength = Int32.MaxValue;
            PrivateStash ro = jsonSerializer.Deserialize<PrivateStash>(json);
            List<StashItemsFiltered> myStash = new List<StashItemsFiltered>();
            int hel = 0;

            foreach (var item in ro.items)
            {
                StashItemsFiltered newItem = new StashItemsFiltered();
                newItem.quadLayout = ro.quadLayout;
                Dictionary<string, object> bla = (Dictionary<string, object>)item;
                
                foreach (var propertyEntry in bla)
                {
                    switch (propertyEntry.Key)
                    {
                        case "category":
                            {
                                Dictionary<string, object> categoryDict = (Dictionary<string, object>)propertyEntry.Value;
                                
                                foreach (var categoryEntry in categoryDict)
                                {
                                    newItem.category = categoryEntry.Key;
                                    object[] subCat = (object[])categoryEntry.Value;
                                    if (subCat.Count()>0)
                                    newItem.subCategory = subCat[0].ToString();
                                    if (newItem.subCategory == "helmet") hel++;
                                }
                                break;
                            }
                        case "typeLine":
                            {
                                string typeLinel = (string)propertyEntry.Value;
                                newItem.typeName = typeLinel;
                                break;
                            }
                        case "icon":
                            {
                                string icon = (string)propertyEntry.Value;
                                newItem.icon = icon;
                                break;
                            }
                        case "id":
                            {
                                string id = (string)propertyEntry.Value;
                                newItem.id = id;
                                break;
                            }
                        case "ilvl":
                            {
                                Int32 ilvl = (Int32)propertyEntry.Value;
                                newItem.itlvl = ilvl;
                                break;
                            }
                        case "x":
                            {
                                Int32 x = (Int32)propertyEntry.Value;
                                newItem.x = x;
                                break;
                            }
                        case "y":
                            {
                                Int32 y = (Int32)propertyEntry.Value;
                                newItem.y = y;
                                break;
                            }
                        case "w":
                            {
                                Int32 w = (Int32)propertyEntry.Value;
                                newItem.w = w;
                                break;
                            }
                        case "h":
                            {
                                Int32 h = (Int32)propertyEntry.Value;
                                newItem.h = h;
                                break;
                            }
                    }
                }
                
                myStash.Add(newItem);
            }
            Debug.WriteLine("Helmets: " + hel);
            return myStash;
        }

        

        public static string getPublicJSON(string next_change_id = null)
        {
            
            string jsonRequest = @"http://www.pathofexile.com/api/public-stash-tabs";
            string result = "";

            if (next_change_id == null)
            {
                next_change_id = PublicStash.GetLatestId();
            }
            Debug.WriteLine("Getting " + next_change_id);
            jsonRequest += "?id=" + next_change_id;
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(jsonRequest);
            WebResponse response = request.GetResponse();

            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream);
                result = reader.ReadToEnd();
                reader.Close();

            }
            return result;
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string getPrivateStashJSON(string PoeCookie, string path)
        {
            
            path  = path + "&character=" + RandomString(6);

            var cookies = new CookieContainer();
            Cookie c = new Cookie("POESESSID", PoeCookie, "/", ".pathofexile.com");
            cookies.Add(c);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
            request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://pathofexile.com/character-window/get-characters");
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(c);
            //request.Credentials = new System.Net.NetworkCredential("piotrek816", "k0l3k0l3k");
            //request.Method = "GET";
            //request.ContentType = "application/json";
            //string autorization = "piotrek816" + ":" + "k0l3k0l3k";
            //byte[] binaryAuthorization = System.Text.Encoding.UTF8.GetBytes(autorization);
            //autorization = Convert.ToBase64String(binaryAuthorization);
            //autorization = "Basic " + autorization;
            //request.Headers.Add("AUTHORIZATION", autorization);

            WebResponse response = request.GetResponse();
            Debug.WriteLine("Response cached: " + response.IsFromCache);
            string result = "";
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                result = reader.ReadToEnd();
                reader.Close();
            }
            return result;
        }

        public static Bitmap GetBitmapFromUrl(string url)
        {
            System.Net.WebRequest request =System.Net.WebRequest.Create(url);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream =
                response.GetResponseStream();
            return new Bitmap(responseStream);
        }
        
        public static IEnumerable<Tuple<string,string>> ReadCookies(string hostName)
        {
            var dbPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+@"\Google\Chrome\User Data\Default\Cookies";
            if (!System.IO.File.Exists(dbPath))
            {
                Debug.WriteLine("Folder doesn't exist");
            }
            else
            {
                var connectionString = "Data Source=" + dbPath + ";pooling=false";
                var conn = new System.Data.SQLite.SQLiteConnection(connectionString);
                var cmd = conn.CreateCommand();

                var prm = cmd.CreateParameter();
                prm.ParameterName = "hostName";
                prm.Value = hostName;
                cmd.Parameters.Add(prm);

                cmd.CommandText = "SELECT name, encrypted_value FROM cookies WHERE host_key = @hostName";
                conn.Open();
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    var encryptedData = (byte[]) reader[1];
                    var decodedData = System.Security.Cryptography.ProtectedData.Unprotect(encryptedData, null, System.Security.Cryptography.DataProtectionScope.CurrentUser);
                    var plainText = Encoding.ASCII.GetString(decodedData);

                    yield return Tuple.Create(reader.GetString(0), plainText);
                }
                conn.Close();
            }
        }
    }
}
