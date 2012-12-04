using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;



class Actor
{
    public string name;
    public List<Film> films = new List<Film>();
    public bool visited = false;
    public Film connect = null;
    public Actor(string n = "none", List<Film> f = null, bool v = false)
    {
        name = n;
        films = f;
        visited = v;
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
            Console.WriteLine(a.Pop().name);
            Console.WriteLine("|\n|");
            Console.WriteLine(f.Pop().name);
            Console.WriteLine("|\n|");
        }
        Console.WriteLine(a.Pop().name);
        Console.WriteLine("degree of separation: " + degree);//show the degree of separation
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

class Film
{
    public string name;
    public List<Actor> cast = new List<Actor>();
    public bool visited = false;
    public Actor connect = null;
    public Film(string n = "none", List<Actor> c = null, bool v = false)
    {
        name = n;
        cast = c;
        visited = v;
    }

}


namespace _470_project
{
    class Program
    {
        static void Main(string[] args)
        {
            //takes our sample file and indexes it into film and actor objects
            const string f = "smallactors.txt";
            List<Film> films = new List<Film>();
            List<Actor> actors = new List<Actor>();
            using (StreamReader r = new StreamReader(f))
            {
                string line;
                bool newactor = true;
                Actor currentActor = new Actor();
                Film currentFilm = new Film();

                while ((line = r.ReadLine()) != null)
                {
                    if (line == "")
                    {
                        newactor = true;
                        continue;
                    }

                    if (newactor == true)
                    {
                        currentActor = new Actor(line, new List<Film>());
                        actors.Add(currentActor);
                        newactor = false;
                    }
                    else
                    {
                        currentFilm = films.Find(delegate(Film film) { return film.name.Equals(line); });
                        if (currentFilm == null)
                        {
                            currentFilm = new Film(line, new List<Actor>());
                            films.Add(currentFilm);
                        }

                        currentFilm.cast.Add(currentActor);
                        currentActor.films.Add(currentFilm);
                    }
                }

                //foreach (Film film in films)
                //{
                //    Console.WriteLine(film.name);
                //    foreach (Actor actor in film.cast)
                //        Console.WriteLine(actor.name);
                //    Console.ReadLine();

                //}
                int x = 0;
                foreach (Actor actor in actors)
                {

                    Console.WriteLine(x + ".)" + actor.name);
                    x++;
                    //foreach (Film film in actor.films)
                    //Console.WriteLine(film.name);
                    //Console.ReadLine();
                }
                //USER INTERFACE
                string input1;
                string input2;
                Console.WriteLine("Select the first actor by it's corresponding number");
                input1 = Console.ReadLine();
                Console.WriteLine("Select the second actor by it's corresponding number");
                input2 = Console.ReadLine();

                string[] words = input1.Split(' ');              
                input1 = words[1]+", "+words[0];
                Actor test = actors.Find(item => item.name == input1);
                
                if (test == null)
                {
                    int minDist = 1000;
                    int tempDist = 0;
                    Actor tempActor = new Actor();
                    Actor bestMatch = new Actor();

                    for (int i = 0; i < actors.Count; i++)
                    {

                        tempDist = tempActor.DamerauLevenshteinDistance(input1, actors[i].name);
                        if (tempDist < minDist)
                        {
                            minDist = tempDist;
                            bestMatch = actors[i];
                        }
                    }
                    test = bestMatch;
                }

                words = input2.Split(' ');
                input2 = words[1] + ", " + words[0];
                Actor queryActor = new Actor();
                queryActor.name = input2;

                Actor test2 = actors.Find(item => item.name == input2);
                if (test2 == null)
                {
                    int minDist = 1000;
                    int tempDist = 0;
                    Actor tempActor = new Actor();
                    Actor bestMatch = new Actor();

                    for (int i = 0; i < actors.Count; i++)
                    {

                        tempDist = tempActor.DamerauLevenshteinDistance(input2, actors[i].name);
                        if (tempDist < minDist)
                        {
                            minDist = tempDist;
                            bestMatch = actors[i];
                        }
                    }
                    test2 = bestMatch;
                }
                

                if (test.DegreeOfSeparation(test2, 1) != -1)
                {

                    Console.WriteLine("good");
                }
                else
                    Console.WriteLine("bad");

                Console.ReadLine();
            }



        }
    }
}