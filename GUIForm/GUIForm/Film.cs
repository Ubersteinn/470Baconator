using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GUIForm
{
    class Film
    {
        private string Name;
        private List<Actor> Cast;
        private bool Visited;
        private Actor Connect;

        public Film(string n = "none", List<Actor> c = null, bool v = false)
        {
            Name = n;
            Cast = c;
            Visited = v;
            Connect = null;
        }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public List<Actor> cast
        {
            get { return Cast; }
            set { Cast = value; }
        }

        public bool visited
        {
            get { return Visited; }
            set { Visited = value; }
        }

        public Actor connect
        {
            get { return Connect; }
            set { Connect = value; }
        }
    }
}
