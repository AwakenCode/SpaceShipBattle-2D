using System;
using Common;
using Ship;

namespace Service
{
    public class ShipSpawner
    {
        private readonly BattleSetupHolder _battleSetupHolder;
        private readonly ShipSpawnPoints _shipSpawnPoints;

        public ShipSpawner(BattleSetupHolder battleSetupHolder, ShipSpawnPoints shipSpawnPoints)
        {
            _battleSetupHolder = battleSetupHolder;
            _shipSpawnPoints = shipSpawnPoints;
        }
        
        public void SpawnShips()
        {
            for (int i = 0; i < Enum.GetNames(typeof(CandidateId)).Length; i++)
            {
                if(i == 1) continue;
                
                var spawnPoint = _shipSpawnPoints.SpawnPoints[(CandidateId) i];
                var ship = _battleSetupHolder.GetShip((CandidateId) i);
                
                ship.transform.SetParent(spawnPoint);
                ship.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
                ship.gameObject.SetActive(true);
            }
        }
    }
}