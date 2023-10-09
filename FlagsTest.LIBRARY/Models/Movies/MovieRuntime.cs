using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsTest.LIBRARY.Models.Movies
{
    public class MovieRuntime
    {
        public int Seconds {  get; set; }

        private decimal _runtimeMinutes;
        public decimal RuntimeMinutes
        {
            get { return _runtimeMinutes; }
            set 
            { 
                _runtimeMinutes = (Seconds / 60);
            }
        }
    }
}
