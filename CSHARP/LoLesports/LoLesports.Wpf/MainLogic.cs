using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LoLesports.Wpf
{
    class MainLogic
    {
        string url = "http://localhost:61451/api/JatekosApi/";

        HttpClient client = new HttpClient();

        void SendMessage(bool success)
        {
            string msg = success ? "Operation completed successfully" : "Operation failed";
            Messenger.Default.Send(msg, "JatekosResult");
        }

        public List<JatekosVM> ApiGetJatekosok()
        {
            string json = client.GetStringAsync(url + "all").Result;
            var list = JsonConvert.DeserializeObject<List<JatekosVM>>(json);
            //SendMessage(true);
            return list;
        }

        public void ApiDelJatekos(JatekosVM jatekos)
        {
            bool success = false;
            if (jatekos != null)
            {
                //string json = client.GetStringAsync(url + "del/" + jatekos.Felhasznalonev).Result; szintén nem megy string miatt
                // JObject obj = JObject.Parse(json);
                success = false;  //(bool)obj["OperationResult"];
            }
            SendMessage(success);
        }

        bool ApiEditJatekos(JatekosVM jatekos, bool isEditing)
        {
            if (jatekos == null) return false;

            string myUrl = isEditing ? url + "mod" : url + "add";

            Dictionary<string, string> postData = new Dictionary<string, string>();

            postData.Add(nameof(JatekosVM.Felhasznalonev), jatekos.Felhasznalonev.ToString());
            postData.Add(nameof(JatekosVM.Vezeteknev), jatekos.Vezeteknev.ToString());
            postData.Add(nameof(JatekosVM.Keresztnev), jatekos.Keresztnev.ToString());
            postData.Add(nameof(JatekosVM.Eletkor), jatekos.Eletkor.ToString());
            postData.Add(nameof(JatekosVM.Pozicio), jatekos.Pozicio.ToString());
            postData.Add(nameof(JatekosVM.Nemzetiseg), jatekos.Nemzetiseg.ToString());
            postData.Add(nameof(JatekosVM.Csapatnev), jatekos.Csapatnev.ToString());

            string json = client.PostAsync(myUrl, new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
            JObject obj = JObject.Parse(json);
            return (bool)obj["OperationResult"];
        }

        public void EditJatekos(JatekosVM jatekos, Func<JatekosVM, bool> editor)
        {
            JatekosVM clone = new JatekosVM();
            if (jatekos != null)
            {
                clone.CopyFrom(jatekos);
            }
            bool? success = editor?.Invoke(clone);

            if (success == true)
            {
                if (jatekos != null)
                {
                    success = ApiEditJatekos(clone, true);
                }
                else
                {
                    success = ApiEditJatekos(clone, false);
                }
            }
            SendMessage(success == true);
        }
    }
}
