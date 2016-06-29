using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programming_Assignment_3
{
    class Game
    {
        public bool isRunning = false;//the main thread loop condition
        public bool allEnemiesDead = false;//the end

        Renderer _renderer;//the game renderer
        public static InputListener _input;//the games input
        public Player _player;//player entity
        public UI _ui;//game ui

        public Level _level;

        public int keys = 0; //amount of keys

        public List<Projectile> projectiles = new List<Projectile>();//projectile list

        public List<Enemy> enemies = new List<Enemy>();//Enemy List

        public Game()
        {
            ShowTitle();

            Console.OutputEncoding = System.Text.Encoding.Unicode;

            //instantiate the engine variables
            _input = new InputListener();
            _renderer = new Renderer(this);
            _player = new Player(new Vector3(6, 6), _input, this);

            _ui = new UI(_player, this);

            //create the level
            LoadLevel();

            //create the games entities
            AddEnemy(new Archer(new Vector3(15, 8), this, 1));
            AddEnemy(new Archer(new Vector3(15, 4), this, 3));
            AddEnemy(new Soldier(new Vector3(12, 15), this, 3));
            AddEnemy(new Boss(new Vector3(12, 15), this, 3));
            AddEnemy(new Soldier(new Vector3(12, 20), this, 3));

            //create pickups
            AddProjectile(new Key(new Vector3(14, 15), "key"));
            AddProjectile(new HealthPickup(new Vector3(14, 8), "health"));
            
            //the games running loop
            while(isRunning){

                _input.Update(); //input update
               
                Update(); //game update

                _renderer.Render();//render update

                System.Threading.Thread.Sleep(50);//make the program sleep for 50 milliseconds
            }
        }

        //create title screen
        public void ShowTitle()
        {
            Console.Clear();
            new TitleScreen(this);
        }

        //creates the level
        public void LoadLevel()
        {
            _level = new Level(32, 32);
        }

        //the update function
        public void Update()
        {

            CheckProjectiles();//check the projectiles for dead projectiles.

            CheckEnemies();//check the enemies for dead entities

            CheckProjectilesForCollision();//check for arrow collision with entities

            UpdateEnemyDireciton();

            CheckClearConditions();

            //update all the game objects
            _player.Update();

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
            //render game objects
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

        //create and add projectile to the projectile array
        public void AddProjectile(Projectile proj)
        {
            projectiles.Add(proj);
            proj._game = this;
        }

        //checks the projectiles and removes them from the list if they're dead
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

            GC.Collect();//remove the dead projectiles from memory
        }

        //destroys projectiles
        public void DestroyProjectile(Projectile p)
        {
            p.OnDeath(this);
            p.isAlive = false;
            projectiles.Remove(p);
        }

        //checks each projectiles position in relation to each entity
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
                else if (p.tag.Contains("key") || p.tag.Contains("health"))
                {
                    if (p.pos.x == _player.pos.x && p.pos.y == _player.pos.y)
                        DestroyProjectile(p);
                    
                }
            }
        }

        //adds a new enemy to the enemies array
        public void AddEnemy(Enemy en)
        {
            enemies.Add(en);
        }

        //checks the enemy array and deletes the ones that are dead.
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

            GC.Collect();
        }

        //destroys an enemy
        public void DestroyEnemy(Enemy e)
        {
            e.isAlive = false;
            e.canAttack = false;
            enemies.Remove(e);
        }

        //called when the player dies
        public void GameOver() 
        {
            Console.Clear();
            isRunning = false;
            GameOver go = new GameOver();
        }

        //set the enemies direction in relation to the player
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

        //checks if all of the enemies are dead, if it is it ends the game.
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
