using HogwartsInscriptionsCore.Enums;
using HogwartsInscriptionsCore.Interfaces;
using HogwartsInscriptionsCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsInscriptionsCore.Workers
{
    public class Inscriptions : IInscriptions
    {
        public IEnumerable<Inscription> GetInscriptions()
        {
            using (var db = new HogwartsContext())
            {
                IEnumerable<Inscription> inscriptions = db.Inscriptions.ToList();
                return inscriptions;
            }
        }

        public bool Create(Inscription inscriptionDto)
        {
            try
            {
                HouseType.Houses housesType = (HouseType.Houses)Enum.ToObject(typeof(HouseType.Houses), int.Parse(inscriptionDto.House));
                StateTypes.States stateType = (StateTypes.States)Enum.ToObject(typeof(StateTypes.States), 1);
                using (var context = new HogwartsContext())
                {
                    Inscription inscription = new Inscription()
                    {
                        Name = inscriptionDto.Name,
                        LastName = inscriptionDto.LastName,
                        DocumentNum = inscriptionDto.DocumentNum,
                        Age = inscriptionDto.Age,
                        House = housesType.ToString(),
                        State = stateType.ToString(),
                        CreatedDate = DateTime.UtcNow,
                    };
                    context.Inscriptions.Add(inscription);
                    return context.SaveChanges() == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Inscription inscriptionDto)
        {
            try
            {
                HouseType.Houses housesType = (HouseType.Houses)Enum.ToObject(typeof(HouseType.Houses), int.Parse(inscriptionDto.House));
                using (var context = new HogwartsContext())
                {
                    var inscription = context.Inscriptions.FirstOrDefault(row => row.Id == inscriptionDto.Id);
                    inscription.Name = inscriptionDto.Name;
                    inscription.LastName = inscriptionDto.LastName;
                    inscription.DocumentNum = inscriptionDto.DocumentNum;
                    inscription.Age = inscriptionDto.Age;
                    inscription.House = housesType.ToString();
                    inscription.UpdatedDate = DateTime.UtcNow;

                    return context.SaveChanges() == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Inscription GetInscription(int id)
        {
            try
            {
                using (var context = new HogwartsContext())
                {
                    return context.Inscriptions.FirstOrDefault(row => row.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool DeleteInscription(int id)
        {
            try
            {
                using (var context = new HogwartsContext())
                {
                    Inscription inscription = context.Inscriptions.FirstOrDefault(row => row.Id == id);
                    context.Remove(inscription);
                    return context.SaveChanges() == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ChangeState(int id, int stateId)
        {
            try {
                StateTypes.States stateType = (StateTypes.States)Enum.ToObject(typeof(StateTypes.States), stateId);
                using (var context = new HogwartsContext())
                {
                    var inscription = context.Inscriptions.FirstOrDefault(row => row.Id == id);
                    inscription.State = stateType.ToString();
                    inscription.UpdatedDate = DateTime.UtcNow;

                    return context.SaveChanges() == 1;
                }
            }catch(Exception ex) {
                throw ex;
            }
        }


    }
}
