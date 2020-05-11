using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Transporter.Wpf
{
    class MainLogic
    {
        string url = "http://localhost:50643/api/CustomerApi/";
        HttpClient client = new HttpClient();

        public void SendMessage(bool success)
        {
            string msg = success ? "Operation completed successfully" : "Operation failed";
            Messenger.Default.Send(msg, "CustomerResult");
        }

        public List<CustomerVM> ApiGetCustomers()
        {
            string json = client.GetStringAsync(url + "all").Result;
            var list = JsonConvert.DeserializeObject<List<CustomerVM>>(json);
            //SendMessage(true);
            return list;
        }

        public void ApiDelCustomer(CustomerVM customer)
        {
            bool success = false;
            if (customer != null)
            {
                string json = client.GetStringAsync(url + "del/" + customer.Id).Result;
                JObject obj = JObject.Parse(json);
                success = (bool)obj["OperationResult"];
            }
            SendMessage(success);
        }

        bool ApiEditCustomer(CustomerVM customer, bool isEditing)
        {
            if (customer == null)
            {
                return false;
            }

            string myUrl = isEditing ? url + "mod" : url + "add";

            Dictionary<string, string> postData = new Dictionary<string, string>();
            if (isEditing)
            {
                postData.Add(nameof(CustomerVM.Id), customer.Id.ToString());
            }
            postData.Add(nameof(CustomerVM.Name), customer.Name);
            postData.Add(nameof(CustomerVM.Adress), customer.Adress);
            postData.Add(nameof(CustomerVM.PhoneNum), customer.PhoneNum);
            postData.Add(nameof(CustomerVM.EMail), customer.EMail);

            string json = client.PostAsync(myUrl, new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
            JObject obj = JObject.Parse(json);
            return (bool)obj["OperationResult"];
        }

        public void EditCustomer(CustomerVM customer, Func<CustomerVM, bool>  editor)
        {
            CustomerVM clone = new CustomerVM();
            if (customer != null)
            {
                clone.CopyFrom(customer);
            }
            bool? success = editor?.Invoke(clone);

            if (success == true)
            {
                if (customer != null) success = ApiEditCustomer(clone, true);
                else success = ApiEditCustomer(clone, false);
            }
            SendMessage(success == true);
        }
    }
}
