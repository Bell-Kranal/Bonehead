using Infrastructure.States;
using Zenject;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        private const string Main = "Main";
        
        public override void InstallBindings()
        {
            IGameStateMachine stateMachine = new GameStateMachine(Container);
            
            Container.Bind<IGameStateMachine>().FromInstance(stateMachine).AsSingle();
            
            stateMachine.Enter<BootstrapState, string>(Main);
        }
    }
}
