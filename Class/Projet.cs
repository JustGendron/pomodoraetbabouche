
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pomodoraetbabouche.Class
{
    [Table("Projet")]
    class Projet
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("nombrePomodoro")]
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
