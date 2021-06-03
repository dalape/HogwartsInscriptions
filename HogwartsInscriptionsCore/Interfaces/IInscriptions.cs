using HogwartsInscriptionsCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsInscriptionsCore.Interfaces
{
    public interface IInscriptions
    {
        IEnumerable<Inscription> GetInscriptions();
        bool Create(Inscription inscriptionDto);
        bool Update(Inscription inscriptionDto);
        Inscription GetInscription(int id);
        bool DeleteInscription(int id);
        bool ChangeState(int id, int stateId);
    }
}
