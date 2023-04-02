using System;
using Ship.Weapon;

namespace Service.Factory
{
    public class GameFactory
    {
        public Ship.Ship CreateShip(ShipType shipType)
        {
            return shipType switch
            {
                ShipType.BSApocalypse => CreateApocalypse(),
                ShipType.CSGuardian => CreateGuardian(),
                ShipType.BCSolarLuisa => CreateSolarLuisa(),
                ShipType.HSConstantine => CreateConstantine(),
                ShipType.SSAvius => CreateAvius(),
                ShipType.HGPegasus => CreatePegasus(),
                _ => throw new ArgumentOutOfRangeException(nameof(shipType), shipType, null)
            };
        
            Ship.Ship CreateGuardian()
            {
                return null;
            }

            Ship.Ship CreateApocalypse()
            {
                return null;
            }

            Ship.Ship CreateAvius()
            {
                return null;
            }

            Ship.Ship CreatePegasus()
            {
                return null;
            }

            Ship.Ship CreateConstantine()
            {
                return null;
            }

            Ship.Ship CreateSolarLuisa()
            {
                return null;
            }
        }

        public Gun CreateGun(WeaponType weaponType)
        {
            return weaponType switch
            {
                WeaponType.BulletGun => CreateBulletGun(),
                WeaponType.PlasmaGun => CreatePlasmaGun(),
                WeaponType.LaserGun => CreateLaserGun(),
                WeaponType.MissileGun => CreateMissileGun(),
                _ => throw new ArgumentOutOfRangeException(nameof(weaponType), weaponType, null)
            };

            Gun CreateBulletGun()
            {
                return null;
            }

            Gun CreatePlasmaGun()
            {
                return null;
            }

            Gun CreateLaserGun()
            {
                return null;
            }

            Gun CreateMissileGun()
            {
                return null;
            }
        }
    }
}