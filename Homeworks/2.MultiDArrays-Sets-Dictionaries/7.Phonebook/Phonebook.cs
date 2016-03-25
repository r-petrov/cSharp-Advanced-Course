using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Phonebook
{
    static void Main(string[] args)
    {
        IDictionary<string, List<string>> contacts = new Dictionary<string, List<string>>();
        IDictionary<string, string> phonebook = new Dictionary<string, string>();
        string inputContatcts = String.Empty;
        List<string> phoneNumbers=new List<string>();
        string[] contactInfo;
        char[] separators = new[] {' ', ',', '-'};
        string contactName = String.Empty;
        string contactNumber = String.Empty;

        while (inputContatcts.ToLower() != "search")
        {
        again:
            inputContatcts = Console.ReadLine();
            if (inputContatcts.ToLower() == "search")
            {
                break;
            }
            contactInfo = inputContatcts.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            contactName = contactInfo[0];
            contactNumber = contactInfo[1];

            if (contactInfo.Length != 2)
            {
                goto again;
            }
            
            phonebook.Add(contactName, contactNumber);
            phoneNumbers.Add(contactNumber);
            contacts.Add(contactName, phoneNumbers);
            phoneNumbers.Clear();
        }

        
        for (int i = 0; i < contacts.Count * 2; i++)
        {
            string searchByName = Console.ReadLine();
            if (contacts.ContainsKey(searchByName))
            {
                //Console.WriteLine("{0} -> {1}", searchByName, contacts[searchByName]);
                Console.WriteLine("{0} -> {1}", searchByName, phonebook[searchByName]);
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", searchByName);
            }
        }
        
    }
}
