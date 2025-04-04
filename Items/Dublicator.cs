using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using InventorySystem.Items.Pickups;
using UnityEngine;

namespace Dublicator.Items {
    [Exiled.API.Features.Attributes.CustomItem(ItemType.GunCOM18)]
    internal class Dublicator : CustomWeapon {
        public override string Description { get; set; } = "Дублює предмети";
        public override float Weight { get; set; } = 2f;
        public override string Name { get; set; } = "Дублiкатор";
        public override uint Id { get; set; } = 122;
        public override ItemType Type { get; set; } = ItemType.GunCOM18;
        public override float Damage { get; set; } = 0;
        public override byte ClipSize { get; set; } = 3;

        protected override void SubscribeEvents() {
            base.SubscribeEvents();
            Exiled.Events.Handlers.Player.Shot += Wapon;
            Exiled.Events.Handlers.Player.ChangedItem += Select_Info;
            Exiled.Events.Handlers.Player.ReloadingWeapon += Reload;
        }

        protected override void UnsubscribeEvents() {
            Exiled.Events.Handlers.Player.Shot -= Wapon;
            Exiled.Events.Handlers.Player.ChangedItem -= Select_Info;
            Exiled.Events.Handlers.Player.ReloadingWeapon -= Reload;
            base.UnsubscribeEvents();
        }

        void Select_Info(ChangedItemEventArgs ev) {
            if (Check(ev.Item)) {
                ev.Player.Broadcast(4, Loader.Instance.Config.Select_information);
            }
        }

        void Wapon(ShotEventArgs ev) {
            if (!Check(ev.Item)) {
                return;
            } if (ev.Firearm.TotalAmmo <= 0) { 
                ev.Player.RemoveItem(ev.Item);
                Map.ExplodeEffect(ev.Player.Position, ProjectileType.FragGrenade);
            } if (ev.Target != null) {
                ev.CanHurt = false;
                Hitmarker.SendHitmarkerDirectly(ev.Player.ReferenceHub, 1.5f);
                Ragdoll.CreateAndSpawn(ev.Target.Role.Type, ev.Target.Nickname, Loader.Instance.Config.Dead_information, ev.Target.Transform.position, ev.Target.Transform.rotation);
            } if (Physics.Linecast(ev.Player.CameraTransform.position, ev.RaycastHit.point, out RaycastHit raycastHit)) {
                if (raycastHit.transform.TryGetComponent(out ItemPickupBase itemPickupBase)) {
                    if (!Loader.Instance.Config.Black_list.Contains(itemPickupBase.NetworkInfo.ItemId)) {
                        Pickup.CreateAndSpawn(itemPickupBase.NetworkInfo.ItemId, ev.RaycastHit.point + Vector3.up * 0.5f, default);
                        Hitmarker.SendHitmarkerDirectly(ev.Player.ReferenceHub, 2);
                    } else {
                        ev.Player.Broadcast(5, Loader.Instance.Config.Error_information);
                        ev.Player.Hurt(30);
                    }
                }
            }
        }

        void Reload(ReloadingWeaponEventArgs ev) {
            if (Check(ev.Item)) {
                ev.IsAllowed = false;
            }
        }

        public override SpawnProperties SpawnProperties { get; set; } = null;
    }
}
