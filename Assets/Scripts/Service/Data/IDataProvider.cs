using Data.Ammunition;
using Data.Scene;
using Data.Ship;
using Data.UI;
using Data.Weapon;
using Ship;
using Ship.Equipment.Weapon;
using Ship.Equipment.Weapon.Ammunition;

namespace Service.Data
{
    public interface IDataProvider
    {
        void Load();
        ShipData GetShipData(ShipType type);
        WeaponData GetWeaponData(WeaponType type);
        SceneData GetSceneData();
        UIData GetUIData();
        AmmunitionData GetAmmunitionData(AmmunitionType type);
        ShipData[] GetAllShipData();
        WeaponData[] GetAllWeaponData();
        AmmunitionData[] GetAllAmmunitionData();
    }
}