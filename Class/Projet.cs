using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pomodoraetbabouche.Class
{
    class Projet
    {
        public int id { get; set; }
        public string name { get; set; }
        public int nombrePomodoro { get; set; }

        public Projet()
        {
        }

        public Projet(int id, string name, int nombrePomodoro)
        {
            this.id = id;
            this.name = name;
            this.nombrePomodoro = nombrePomodoro;
        }
    }
}
