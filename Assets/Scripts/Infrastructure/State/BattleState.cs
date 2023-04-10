using Service;
using Service.Factory;

namespace Infrastructure.State
{
    public class BattleState : IState
    {
        private readonly Curtain _curtain;
        private readonly UIFactory _uiFactory;
        private readonly ShipSpawner _shipSpawner;

        public BattleState(Curtain curtain, UIFactory uiFactory, ShipSpawner shipSpawner)
        {
            _curtain = curtain;
            _uiFactory = uiFactory;
            _shipSpawner = shipSpawner;
        }
        
        public void Enter()
        {
            PrepareUI();
            _shipSpawner.SpawnShips();
            _curtain.Hide();
        }
        
        private void PrepareUI()
        {
            _uiFactory.CreateBattleWindow();
        }
    }
}