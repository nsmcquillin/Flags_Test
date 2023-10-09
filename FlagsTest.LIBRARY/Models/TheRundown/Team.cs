using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsTest.LIBRARY.Models.TheRundown
{
    public class Team
    {

        public int Team_Id { get; set; }
        public int Name { get; set; }

        public int Mascot { get; set; }

        public string Record { get; set; }

        public List<Team> Teams { get; set; }

    }
}
