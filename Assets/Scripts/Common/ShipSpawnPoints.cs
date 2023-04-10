using System.Collections.Generic;
using Ship;
using UnityEngine;

namespace Common
{
    public class ShipSpawnPoints : MonoBehaviour
    {
        [SerializeField] private Transform _shipASpawnPoint;
        [SerializeField] private Transform _shipBSpawnPoint;

        public Dictionary<CandidateId, Transform> SpawnPoints { get; } = new();

        public void Initialize()
        {
            SpawnPoints[CandidateId.SpaceShipA] = _shipASpawnPoint;
            SpawnPoints[CandidateId.SpaceShipB] = _shipBSpawnPoint;
        }
    }
}