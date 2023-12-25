using System;
using SimpleSnake.Core.Interfaces;
using SimpleSnake.Utilities;

namespace SimpleSnake.GameObjects
{
    public class GameObject : Point, IDrawable 
    {
        public GameObject(char drawSymbol) 
            : base(0,0)
        {
            DrawSymbol = drawSymbol;
        }

        public GameObject(char drawSymbol, int x, int y) 
            : base(x,y)
        {       
            DrawSymbol = drawSymbol;
        }
        public  char DrawSymbol { get; }


        public virtual void Draw()
        {
           Platformnteraction.Draw(this);
        }
        
    }
}
