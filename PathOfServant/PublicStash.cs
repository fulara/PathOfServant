using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using static PathOfServant.Form1;

namespace PathOfServant
{
    class PublicStash
    {
        public static void fillRootObjects(Stash charStash, string charName, string nextCHnageId = null)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            jsonSerializer.MaxJsonLength = Int32.MaxValue;
            string result = WebTools.getPublicJSON(nextCHnageId);
            if (result.Contains(charName))
            {

                RootObject ro = jsonSerializer.Deserialize<RootObject>(result);
                Debug.WriteLine("Yagami found!" + ro.next_change_id);
                foreach (Stash stash in ro.stashes)
                {
                    if (stash.lastCharacterName == charName)
                    {
                        charStash = stash;
                    }
                }
            }
            else
            {
                Debug.WriteLine("no " + charName + "...");
            }
            if (result.Length > 100)
            {
                string resultBegining = result.Substring(0, 100);
                nextCHnageId = resultBegining.Split('\"')[3];
            }
            else
            {
                Debug.WriteLine("not ready repeat");
            }
            fillRootObjects( charStash, charName, nextCHnageId);
        }

        public static string GetLatestId(string path = "http://api.poe.ninja/api/Data/GetStats")
        {
            string result = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
            WebResponse response = request.GetResponse();

            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream);
                result = reader.ReadToEnd();
            }

            if (result.Length > 40)
            {
                string id = result.Split('\"')[5];
                Debug.WriteLine("Synchro to " + id);
                return id;

            }
            else
            {
                return null;
            }
        }
    }
}
