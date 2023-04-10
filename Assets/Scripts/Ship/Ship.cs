using Data.Ship;
using UnityEngine;

namespace Ship
{
    public class Ship : MonoBehaviour
    {
        [field: SerializeField] public ShipGuns ShipGuns { get; private set; }
        
        public ShipData ShipData { get; private set; }

        public void Init(ShipData shipData)
        {
            ShipData = shipData;
        }
    }
}