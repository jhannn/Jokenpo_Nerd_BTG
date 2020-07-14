using DesafioBTG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBTG.Services
{
    public interface IMovementsTypeService
    {
        public List<MovementType> GetAll();
    }
}
