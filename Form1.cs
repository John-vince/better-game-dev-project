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
        int x, y;
       public enum TileType
        {
            Hero,
            Enemy,
            Gold,
            Weapon
        }
        public int Get_x()
        {
            return x;
        }
        public int Get_y()
        {
            return y;
        }

        public void Constructor()
        {

        }

        public void Constructor(int _x, int _y)
        { 
            
            x = _x; y = _y; 
        
        }

    }
    class Character : tile //true base class for Hero and Goblin classes.
    {

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