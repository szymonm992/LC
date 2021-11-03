using Zenject;
using LC.Inventory.Main;
using UnityEngine;

namespace LC.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {

        [Header("--inventory--")]
        [SerializeField] private LC.Inventory.Main.Inventory inv;
        [SerializeField] private Inventory_operators uinv_operator;
        [SerializeField] private Inventory_DB uinv_db;

        [Header("--ui--")]
        [SerializeField] private GameObject ui_slots_parent;
        [SerializeField] private GameObject ui_description;


        public override void InstallBindings()
        {
            InstallGameManager();
        }

        private void InstallGameManager()
        {
            Container.BindInterfacesAndSelfTo<LC.Inventory.Main.Inventory>().FromInstance(inv).AsSingle();
            Container.BindInterfacesAndSelfTo<Inventory_operators>().FromInstance(uinv_operator).AsSingle();
            Container.BindInterfacesAndSelfTo<Inventory_DB>().FromInstance(uinv_db).AsSingle().NonLazy();

            Container.Bind<GameObject>().WithId("ui_slots_parent").FromInstance(ui_slots_parent).NonLazy();
            Container.Bind<GameObject>().WithId("ui_description").FromInstance(ui_description).NonLazy();
        }

    }
}