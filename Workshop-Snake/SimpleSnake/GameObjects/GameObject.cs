using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    internal class GameObject : Point, IDrawable 
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
        char DrawSymbol { get; }


        public void Draw()
        {
            // TODO : Draw in platform specific 

            throw new NotImplementedException();
        }
        
    }
}
