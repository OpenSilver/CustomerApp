using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CustomerData
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsMember { get; set; }
    }

    public class DataManager
    {
        private readonly ObservableCollection<Customer> _customers = new ObservableCollection<Customer>
        {
            new Customer { FirstName = "William",  LastName = "Harris",  Email = "william@opensilver.net",  IsMember = true },
            new Customer { FirstName = "Robert",   LastName = "Garza",   Email = "robert1@opensilver.net",  IsMember = false },
            new Customer { FirstName = "Ian",      LastName = "Gates",   Email = "ian@opensilver.net",      IsMember = false },
            new Customer { FirstName = "Lior",     LastName = "Caprio",  Email = "lior1@opensilver.net",    IsMember = true },
            new Customer { FirstName = "Robert",   LastName = "Feldman", Email = "robert2@opensilver.net",  IsMember = false },
            new Customer { FirstName = "Scarlett", LastName = "Koller",  Email = "scarlett@opensilver.net", IsMember = true },
            new Customer { FirstName = "Prag",     LastName = "Smith",   Email = "prag@opensilver.net",     IsMember = true },
            new Customer { FirstName = "Lior",     LastName = "Field",   Email = "lior2@opensilver.net",    IsMember = false }
        };

        public ObservableCollection<Customer> Customers { get; }

        public DataManager()
        {
            Customers = new ObservableCollection<Customer>(_customers);
        }

        private void Reset()
        {
            Customers.Clear();
            foreach (var i in _customers)
            {
                Customers.Add(i);
            }
        }

        public void UpdateData(string name, bool? is_member)
        {
            Reset();

            if (!String.IsNullOrEmpty(name))
            {
                var items = Customers.Where(x => x.FirstName != name).ToList();
                foreach (var i in items)
                {
                    Customers.Remove(i);
                }
            }

            if (is_member.HasValue && is_member.Value)
            {
                var items = Customers.Where(x => !x.IsMember).ToList();
                foreach (var i in items)
                {
                    Customers.Remove(i);
                }
            }
        }
    }
}
