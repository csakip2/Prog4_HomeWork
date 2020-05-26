using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transporter.Wpf
{
    class CustomerVM : ObservableObject
    {
        private int id;
        private string name;
        private string adress;
        private string phoneNum;
        private string eMail;

        public string EMail
        {
            get { return eMail; }
            set { Set(ref eMail, value); }
        }


        public string PhoneNum
        {
            get { return phoneNum; }
            set { Set(ref phoneNum, value); }
        }


        public string Adress
        {
            get { return adress; }
            set { Set(ref adress, value); }
        }


        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }


        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        public void CopyFrom(CustomerVM other)
        {
            if (other == null)
            {
                return;
            }

            this.Id = other.Id;
            this.Name = other.Name;
            this.Adress = other.Adress;
            this.PhoneNum = other.PhoneNum;
            this.EMail = other.Adress;
        }
    }
}
