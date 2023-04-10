using System.Collections.Generic;
using Ship;

namespace Service
{
    public class BattleSetupHolder
    {
        private readonly Dictionary<CandidateId, Ship.Ship> _ships = new();

        public void SetShip(CandidateId candidateId, Ship.Ship ship) => _ships[candidateId] = ship;
        public Ship.Ship GetShip(CandidateId candidateId) => _ships[candidateId];
    }
}