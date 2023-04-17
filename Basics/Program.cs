namespace Basics
{


    class Lead
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal TotalAmount { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Input the minimal amount of shopping");
            decimal minimalValue = decimal.Parse(Console.ReadLine());

            using (StreamReader sr = new StreamReader("C:\\Users\\Usuario\\source\\repos\\Basics\\Basics\\clientes.csv"))
            {
                List<Lead> leads = new List<Lead>();


                while (!sr.EndOfStream)
                {
                    string line = await sr.ReadLineAsync();
                    string[] atributes = line.Split(',');
                    Lead lead = new Lead()
                    {
                        Name = atributes[0],
                        Email = atributes[1],
                        TotalAmount = decimal.Parse(atributes[2])
                    };

                    leads.Add(lead);

                }

                var selectedLeads = from l in leads
                                    where l.TotalAmount >= minimalValue
                                    select l;

                foreach (var selectedLead in selectedLeads)
                {
                    Console.WriteLine("Name: {0}\nEmail: {1}\nTotal Ammount: ${2}\n", selectedLead.Name, selectedLead.Email, selectedLead.TotalAmount);
                }

            }
        }
    }
}

