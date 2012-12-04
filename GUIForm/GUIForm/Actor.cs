using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUIForm
{
    class Actor
    {
        private string Name;
        private List<Film> Films;
        private bool Visited;
        private Film Connect;
        private TextBox outputBox;
        public Actor(string n = "none", List<Film> f = null, TextBox output = null, bool v = false)
        {
            Name = n;
            Films = f;
            outputBox = output;
            Visited = v;
            Connect = null;
        }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public List<Film> films
        {
            get { return Films; }
            set { Films = value; }
        }
        public bool visited
        {
            get { return Visited; }
            set { Visited = value; }
        }
        public Film connect
        {
            get { return Connect; }
            set { Connect = value; }
        }

        public int Path(Actor actor)        //works backwards and dumps the path into a stack to display it later in the proper order
        {
            int degree = 1;
            Stack<Actor> a = new Stack<Actor>();
            Stack<Film> f = new Stack<Film>();
            Film temp = this.connect;
            a.Push(this);
            if (temp.connect == actor)      //this is the case if there is only one degree of separation
            {
                f.Push(temp);
                a.Push(actor);
            }
            else
            {
                while (temp.connect != actor)   //else go through path 
                {
                    f.Push(temp);
                    a.Push(temp.connect);
                    temp = temp.connect.connect;
                }
                f.Push(temp);
                a.Push(temp.connect);
            }
            degree = f.Count;
            while (a.Count > 1)             //display the path
            {
                outputBox.AppendText(Environment.NewLine + a.Pop().name);
                outputBox.AppendText(Environment.NewLine + "|\n|");
                outputBox.AppendText(Environment.NewLine + f.Pop().name);
                outputBox.AppendText(Environment.NewLine + "|\n|");
            }
            outputBox.AppendText(Environment.NewLine + a.Pop().name);
            outputBox.AppendText(Environment.NewLine + "degree of separation: " + degree);//show the degree of separation
            return degree;
        }

        public int DegreeOfSeparation(Actor actor, int degree)
        {
            List<Actor> q = new List<Actor>();
            q.Add(this);
            while (q.Count > 0)
            {
                foreach (Film film in q[0].films)   //go through each film of this actor
                {
                    if (film.visited == false)  //checks if film has been checked already
                    {
                        film.visited = true;
                        film.connect = q[0];
                        foreach (Actor person in film.cast)     //Goes through the cast of each film
                        {
                            if (person.visited == false)    //checks if actor has been visited yet
                            {
                                person.connect = film;
                                person.visited = true;
                                if (person.name == actor.name)     //if actor connection found then use Path() to display path of separation
                                {
                                    person.Path(this);

                                    return 1;

                                }
                                q.Add(person);
                            }
                        }
                    }
                }

                q.RemoveAt(0);
            }
            return -1;
        }

    }
}
