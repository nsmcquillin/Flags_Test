using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlagsTest.LIBRARY.Models.TheRundown
{
    public class Sport
    {
       
        public int Sport_Id { get; set; }
        
        public string Sport_Name { get; set; }

        public List<Team> Teams { get; set; }

    }
}
