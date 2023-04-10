using System.Threading.Tasks;
using Service.Factory;
using UI;

namespace Service
{
    public class Curtain
    {
        private readonly UIFactory _uiFactory;
        private readonly SceneLoader _sceneLoader;

        private CurtainUI _curtainUI;

        public Curtain(UIFactory uiFactory, SceneLoader sceneLoader)
        {
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
        }

        public async Task Initialize()
        {
            _curtainUI = await _uiFactory.CreateCurtain();
            _sceneLoader.AddDontDestroyObject(_curtainUI.gameObject);
        }

        public void Show() => _curtainUI.Show();

        public void Hide() => _curtainUI.Hide();
    }
}