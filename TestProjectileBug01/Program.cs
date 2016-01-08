using System;
using System.Collections.Generic;
using System.Linq;
using Ensage;
using Ensage.Common;

namespace TestProjectileBug01
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Game.OnUpdate += Game_OnUpdate;
        }

        private static void Game_OnUpdate(EventArgs args)
        {
            if (!Game.IsInGame && !Game.IsWatchingGame)
            {
                _projectileCache = new List<Projectile>();
                return;
            }

            CacheProjectiles();
        }

        private static List<Projectile> _projectileCache = new List<Projectile>();
        private static void CacheProjectiles()
        {
            if (Utils.SleepCheck("projectileCache"))
            {
                try
                {
                    if (ObjectMgr.Projectiles != null && ObjectMgr.Projectiles.Any())
                    {
                        _projectileCache = ObjectMgr.Projectiles
                            .Where(x => x.Source != null)
                            .ToList();
                    }
                }
                catch
                {
                    // ignore
                }
                Utils.Sleep(200, "projectileCache");
            }
        }
    }
}
