using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace better_game_dev_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // getting this ready
            Hero hero = new Hero();
            hero.ReturnMove(e.KeyChar);
        }
    }

    class tile //Tile is the base class for all in‐game objects that have positions on the map.
    {
        // our vars for tile
        int x, y;
        public enum TileType // our enums to dertermin the tile type.
        {
            Hero,
            Enemy,
            Gold,
            Weapon
        }
        public int Get_x() // gives caller the x value. I donno what else to tell yea cheef
        {
            return x;
        }
        public int Get_y() // gives caller the y value. I donno what else to tell yea cheef
        {
            return y;
        }

        public void tile_Constructor() // just an overload constructor
        {

        }

        public void tile_Constructor(int _x, int _y) // the true constructor that brings this object into being.
        {
            x = _x;
            y = _y;

        }

    }

    class Obstacle : tile // just provides obstacles.
    {
        public void Obstacle_Constructor(int _x, int _y)
        {
            this.tile_Constructor(_x, _y);
        }
    }

    class emptytile : tile
    {
        public void emptytile_constructor(int _x, int _y) // just adds an empty space
        {
            this.tile_Constructor(_x, _y);
        }
    }
    class Character : tile //true base class for Hero and Goblin classes.
    {
        string name;
        int HP, Max_hp, Damage;
        public int Get_HP()
        { return HP; }
        public int Get_Max_Hp()
        { return Max_hp; }
        public int Get_Damage()
        {
            return Damage;
        }
        public string[] Tile = new string[4];

        public enum Movement
        {
            No_movement
            , Up
            , Down
            , Left
            , Right
        }

        public void Constructor_Character(int x, int y)
        {
            this.tile_Constructor(x, y);
        }
        public void Constructor_Character(int x, int y, int _attack, int _HP)
        {
            this.tile_Constructor(x, y);
            HP = _HP;
            Max_hp = _HP;
            Damage = _attack;

        }
        public virtual void Attack(string target, int damage)
        {
            // some code must go in here that can target a perticular enermy or player but character doesn't have that type of idenitfier in the instructions so far, so I'll just make one for now
            if (this.name == target) // pretty sure this won't work :/
            {
                HP = HP - damage;
            }
        }
        public bool IsDead()
        {
            if (HP == 0)
                return true;
            else
                return false;
        }
        public virtual bool CheckRange(string target, int x, int y) // todistance's function is intergrated with check range because I am not making that converlooted function work at this time
        {
            if (this.name == target)
            {
                if ((this.Get_x() - x) < 2)
                {
                    if (this.Get_y() - y < 2)
                    { return true; }
                    else
                    { return false; }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
                // if this triggers it would be an error but it wants so kind of return so I guess if it fails to find a target it will just say false
            }
        }

        public void Move(int move = 0)
        {
            int _hold;
            switch (move)
            {
                case 0:

                    break;
                case 1:
                    _hold = this.Get_y();
                    _hold = _hold + 1;
                    this.Constructor_Character(this.Get_x(), _hold);
                    break;
                case 2:
                    _hold = this.Get_y();
                    _hold = _hold - 1;
                    this.Constructor_Character(this.Get_x(), _hold);
                    break;
                case 3:
                    _hold = this.Get_x();
                    _hold = _hold + 1;
                    this.Constructor_Character(_hold, this.Get_y());
                    break;
                case 4:
                    _hold = this.Get_x();
                    _hold = _hold - 1;
                    this.Constructor_Character(_hold, this.Get_y());
                    break;
                default:

                    break;
            }
        }
        public Movement ReturnMove(Movement move = 0)
        {
            // break is unreachable so i removed it by commenting it out. i left the breaks as comments so I could more easily read the code
            switch (move)
            {
                case Movement.No_movement:
                    return Movement.No_movement;
                //break;
                case Movement.Up:
                    if (this.Tile[1] != "X")
                    {
                        return Movement.Up;
                    }
                    else
                        return Movement.No_movement;
                // break;
                case Movement.Down:
                    if (this.Tile[2] != "X")
                    {
                        return Movement.Down;
                    }
                    else
                        return Movement.No_movement;
                // break;
                case Movement.Left:
                    if (this.Tile[3] != "X")
                    {
                        return Movement.Left;
                    }
                    else
                        return Movement.No_movement;
                // break;
                case Movement.Right:
                    if (this.Tile[4] != "X")
                    {
                        return Movement.Right;
                    }
                    else
                        return Movement.No_movement;
                // break;
                default:
                    return Movement.No_movement;
                    //  break;

            }
        }

        // the tostring thing is ment to be here but I have no idea what that thing does or how to set it up.
    }
    class Enemy : Character //contains a single protected member variable that is used internally by subclasses
    {
        public Random random = new Random();
        public void Constructor_Enermy(int x, int y, int attack, int HP)
        {
            this.Constructor_Character(x, y, attack, HP);
        }

        public string _Tostring(string name, int x, int y, int damage) //not the "tostring override" thing wanted but it should work
        {
            return name + " at [" + x + ", " + y + "] (" + damage + ")";
        }

    }

    class Goblin : Enemy
    {
        public void Construtor_Goblin(int x, int y)
        {
            this.Constructor_Enermy(x, y, 1, 10);
        }

        public Movement ReturnMove(Movement move = 0)
        {
            var v = Enum.GetValues(typeof(Movement));
            return (Movement)v.GetValue(random.Next(v.Length));
        }
    }
    class Hero : Character
    {
        public void Constructor_Hero(int x, int y, int HP)
        {
            this.Constructor_Character(x, y, 2, HP);
        }
        public Movement ReturnMove(char key)
        {

            switch (key)
            {
                case ' ':
                    return Movement.No_movement;
                //break;
                case 'w':

                    if (this.Tile[1] != "X")
                    {
                        return Movement.Up;
                    }
                    else
                        return Movement.No_movement;
                // break;
                case 's':
                    if (this.Tile[2] != "X")
                    {
                        return Movement.Down;
                    }
                    else
                        return Movement.No_movement;
                // break;
                case 'a':
                    if (this.Tile[3] != "X")
                    {
                        return Movement.Left;
                    }
                    else
                        return Movement.No_movement;
                // break;
                case 'd':
                    if (this.Tile[4] != "X")
                    {
                        return Movement.Right;
                    }
                    else
                        return Movement.No_movement;
                // break;
                default:
                    return Movement.No_movement;
                    //  break;

            }
        }

        public string _Tostring(string name, int x, int y, int damage, int HP, int Max_HP) //not the "tostring override" thing wanted but it should work
        {
            return "Player stats " + "\n" + "HP: " + HP + "/" + Max_HP + "\n" + "Damage: " + damage + "\n" + "[" + x + ", " + y + "]";
        }


    }


    class Map
    {
        char[,] Tile;
        Enemy[] enermy_array;
        int _x_max = 0;
        int _y_max = 0;

        Hero _hero = new Hero();
        Enemy _enemy = new Enemy();


        public void Map_constructor(int _min_width, int _max_width, int _min_height, int _max_height, int _enermy_amount)
        {
            _x_max = random.Next(_min_width, _max_width);
            _y_max = random.Next(_min_height, _max_height);
            Tile = new char[_x_max, _y_max];
            _hero.Constructor_Hero(1, 1, 15);
            enermy_array = new Enemy[_enermy_amount];
            for (int i = 0; i < enermy_array.Length; i++)
            {
                int _X, _Y;
                _X = random.Next(_x_max - 1);
                _Y = random.Next(_y_max - 1);
                _enemy.Constructor_Enermy(_X, _Y, 5, 10); // I could add checks so they don't end up on the same space... buuut I couldn't be bothered currently :/
                enermy_array[i] = _enemy;
                Tile[_X, _Y] = 'G';
            }
            _start_map();
        }

        Random random = new Random();

        private void _start_map()
        {

            //creates the top and bottom half of the map boarder.
            for (int i = 0; i < _x_max; i++)
            {
                Tile[i, 0] = 'x';
            }

            for (int i = 0; i < _x_max; i++)
            {
                Tile[i, _y_max] = 'x';
            }
            //creates the sides of the map
            for (int i = 0; i < _y_max; i++)
            {
                Tile[0, i] = 'x';
            }

            for (int i = 0; i < _y_max; i++)
            {
                Tile[_x_max, i] = 'x';
            }
            // create the start position
            Tile[1, 1] = 'H';

        }

        public void UpdateVision()
        {
            int _X, _Y;
            _X = _hero.Get_x();
            _Y = _hero.Get_y();

            _hero.Tile[1] = Convert.ToString(Tile[_X + 1, _Y]);
            _hero.Tile[2] = Convert.ToString(Tile[_X - 1, _Y]);
            _hero.Tile[3] = Convert.ToString(Tile[_X, _Y + 1]);
            _hero.Tile[4] = Convert.ToString(Tile[_X, _Y - 1]);

            for (int i = 0; i < enermy_array.Length; i++)
            {
                /* int _X, _Y;
                 _X = random.Next(_x_max - 1);
                 _Y = random.Next(_y_max - 1);
                 _enemy.Constructor_Enermy(_X, _Y, 5, 10); // I could add checks so they don't end up on the same space... buuut I couldn't be bothered currently :/
                 enermy_array[i] = _enemy;
                 Tile[_X, _Y] = 'G';*/
                enermy_array[i].Tile[1] = Convert.ToString(Tile[_X + 1, _Y]);
                enermy_array[i].Tile[2] = Convert.ToString(Tile[_X - 1, _Y]);
                enermy_array[i].Tile[3] = Convert.ToString(Tile[_X, _Y + 1]);
                enermy_array[i].Tile[4] = Convert.ToString(Tile[_X, _Y - 1]);

            }


        }


    }
    class  GameEngine
    {

    }
        
    


}