using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace JsonTextGenerator {

    public delegate void AddElementEvent(Point p);

    class Manager {
        public static Frame mainFrame;
        public static Point pos = new Point(0,0);
        public static event AddElementEvent changePos;


        public static void MovePos(Point item, bool inv = true) {
            pos.X += item.X;
            pos.Y += item.Y;

            if (pos.Y == 3)
                pos.Y = 0;

            if(inv) 
                changePos?.Invoke(pos);
        }
    }
}
