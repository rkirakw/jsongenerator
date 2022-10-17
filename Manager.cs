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
    class ChangeTrackList: List<Point> {
        public event AddElementEvent listChangedEvent;

        public new void Add(Point item) {
            base.Add(item);
            listChangedEvent?.Invoke(item);
        }
    }

    class Manager {
        public static Frame mainFrame;
        public static ChangeTrackList qPoints;

        static Manager() {
            qPoints = new ChangeTrackList();
        }

        public static void Add(Point item) {
            qPoints.Add(item);
        }
    }
}
