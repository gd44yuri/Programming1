﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programming_Assignment_3
{
    class Game
    {
        public bool isRunning = false;
        public bool allEnemiesDead = false;

        Renderer _renderer;
        public static InputListener _input;
        public Player _player;
        public UI _ui;

        public Level _level;

        public int keys = 1;

        public List<Projectile> projectiles = new List<Projectile>();

        public List<Enemy> enemies = new List<Enemy>();

        public Game()
        {
            ShowTitle();

            Console.OutputEncoding = System.Text.Encoding.Unicode;

            _input = new InputListener();
            _renderer = new Renderer(this);
            _player = new Player(new Vector3(6, 6), _input, this);

            _ui = new UI(_player, this);

            LoadLevel();

            AddEnemy(new Archer(new Vector3(15, 8), this, 1));
            AddEnemy(new Archer(new Vector3(15, 4), this, 3));
            AddEnemy(new Soldier(new Vector3(12, 15), this, 3));

            AddEnemy(new Boss(new Vector3(12, 15), this, 3));

            AddEnemy(new Soldier(new Vector3(12, 20), this, 3));

            AddProjectile(new Key(new Vector3(14, 15), "key"));
            AddProjectile(new HealthPickup(new Vector3(14, 8), "health"));
            
            //GetDeltaTime();
            while(isRunning){

                GetDeltaTime();

                _input.Update();
               
               
                Update();

                _renderer.Render();

                System.Threading.Thread.Sleep(50);
            }
        }

        public void LoadLevel()
        {
            _level = new Level(32, 32);
        }

        static long lastTime = 0;
        static double GetDeltaTime()
        {
            long now = DateTime.Now.Ticks;
            double dT = (now - lastTime);
            lastTime = now;
            return dT;
        }


        public void Update()
        {

            _player.Update();

            CheckProjectiles();

            CheckEnemies();

            CheckProjectilesForCollision();

            UpdateEnemyDireciton();

            CheckClearConditions();

            foreach (Projectile p in projectiles.Reverse<Projectile>())
            {
                if(p!=null)
                p.Update();
            }

            foreach (Enemy e in enemies)
            {
                e.Update();
            }

            _ui.Update();
        }

        public void Render(Renderer r)
        {
            _level.Render(r);


            _player.Render(r);

            CheckProjectiles();

            CheckEnemies();

            foreach (Projectile p in projectiles.Reverse<Projectile>())
            {
                p.Render(r);
            }

            foreach (Enemy e in enemies)
            {
                e.Render(r);
            }

            _ui.Render(r);
        }

        public void AddProjectile(Projectile proj)
        {
            projectiles.Add(proj);
            proj._game = this;
        }

        public void CheckProjectiles()
        {
            List<Projectile> np = new List<Projectile>();
            foreach (Projectile p in projectiles.Reverse<Projectile>()) 
            {
                if (p != null)
                {
                    if (p.isAlive)
                    {
                        np.Add(p);
                    }
                }
            }

            projectiles = np;

            GC.Collect();
        }

        public void DestroyProjectile(Projectile p)
        {
            p.OnDeath(this);
            p.isAlive = false;
            projectiles.Remove(p);
        }

        public void CheckProjectilesForCollision()
        {
            List<Projectile> np = new List<Projectile>();
            np = projectiles;
            foreach (Projectile p in np.Reverse<Projectile>())
            {
                if (p.owner == 'P')
                {
                    foreach (Enemy e in enemies.Reverse<Enemy>())
                    {
                        if (p.pos.x == e.pos.x && p.pos.y == e.pos.y)
                        {
                            if (p.tag.Contains("hurt"))
                            {
                                e.TakeDamage(_player.attackPower);
                                DestroyProjectile(p);
                            }
                        }
                    }
                }
                else if (p.owner == 'E')
                {
                    if (p.pos.x == _player.pos.x && p.pos.y == _player.pos.y)
                    {
                        _player.TakeDamage(p.power);
                        DestroyProjectile(p);
                        Debug.WriteLine("Health: " + _player.HP);
                    }
                }
                else if (p.tag.Contains("key"))
                {
                    if (p.pos.x == _player.pos.x && p.pos.y == _player.pos.y)
                    {
                        DestroyProjectile(p);
                    }
                }
                else if (p.tag.Contains("health"))
                {
                    if (p.pos.x == _player.pos.x && p.pos.y == _player.pos.y)
                    {
                        DestroyProjectile(p);
                    }
                }
            }
        }

        public void AddEnemy(Enemy en)
        {
            enemies.Add(en);
        }

        public void CheckEnemies()
        {
            List<Enemy> ne = new List<Enemy>();
            foreach (Enemy e in enemies)
            {
                if (e != null)
                {
                    if (e.isAlive)
                    {
                        ne.Add(e);
                    }
                }
            }
            enemies = ne;
        }

        public void DestroyEnemy(Enemy e)
        {
            e.isAlive = false;
            e.canAttack = false;
            enemies.Remove(e);
        }

        public void ShowTitle() {
            Console.Clear();
            TitleScreen ts = new TitleScreen(this);
        }

        public void GameOver() 
        {
            Console.Clear();
            isRunning = false;
            GameOver go = new GameOver();
        }

        public void UpdateEnemyDireciton()
        {
            foreach (Enemy e in enemies)
            {
                if (_player.pos.x < e.pos.x) //Player is at the left of the enemy.
                {
                    e.direction = 3;
                }
                else if (_player.pos.x > e.pos.x)
                {
                    e.direction = 1;
                }
                else if (_player.pos.y < e.pos.y) //Player is above of the enemy.
                {
                    e.direction = 0;
                }
                else if (_player.pos.y > e.pos.y)
                {
                    e.direction = 2;
                }
            }
        }

        public void CheckClearConditions()
        {
            Debug.WriteLine(enemies.Count);

            if (enemies.Count == 0)
            {
                allEnemiesDead = true;
            }

            if (allEnemiesDead)
            {
                Console.Clear();
                GameClear gc = new GameClear();
            }
        }
    }
}
