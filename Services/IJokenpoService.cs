using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBTG.Services
{
    public interface IJokenpoService
    {
        public string Play(string namePlayer1, string namePlayer2);
        public string Reset();
    }
}
