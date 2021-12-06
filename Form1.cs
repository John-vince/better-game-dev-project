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
        public void emptytile_constructor(int _x,int _y) // just adds an empty space
        {
            this.tile_Constructor(_x,_y);
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
        string[] Tile;

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

    }
    class Enemy : Character //contains a single protected member variable that is used internally by subclasses
    {

    }

    class Goblin : Enemy
    {

    }
    class Hero : Character
    {

    }

}