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
    public Actor(string n = "none", List<Film> f = null, bool v = false)
    {
        name = n;
        films = f;
        visited = v;
    }

    public bool findFilm(string film)
    {
        for (int i = 0; i < films.Count; i++)
        {
            if (films[i].name == film)
            {
                return true;
            }
        }
        return false;
    }

    //public override bool Equals(object obj)
    //{
    //    Actor o = obj as Actor;
    //    if (o == null)
    //        return false;
    //
    //    return this.name.Equals(o.name);
    //}
}

class Film
{
    public string name;
    public List<Actor> cast = new List<Actor>();
    public bool visited = false;
    public Film(string n = "none", List<Actor> c = null, bool v = false)
    {
        name = n;
        cast = c;
        visited = v;
    }

    public bool findActor(string actor)
    {
        for (int i = 0; i < cast.Count; i++)
        {
            if (cast[i].name == actor)
            {
                return true;
            }
        }
        return false;
    }

    //public override bool Equals(object obj)
    //{
    //    Film o = obj as Film;
    //    if(o == null)
    //        return false;
    //    
    //   return this.name.Equals(o.name);
    //}

}


namespace _470_project
{
    class Program
    {
        //List<Film> films = new List<Film>();
        //List<Actor> actors = new List<Actor>();


        static void Main(string[] args)
        {
            const string f = "smallactors.txt";

            

            //Film oscar = new Film();
            //Film globe = new Film();
            //Film best = new Film();

            List<Film> films = new List<Film>();
            List<Actor> actors = new List<Actor>();

            //List<Film> A = new List<Film> { oscar };
            //List<Film> B = new List<Film> { oscar, globe };
            //List<Film> C = new List<Film> { globe, best };

            //Actor jim = new Actor("jim", A, false);
            //Actor jane = new Actor("jane", B, false);
            //Actor joe = new Actor("joe", C, false);

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

                foreach (Film film in films)
                {
                    Console.WriteLine(film.name);
                    foreach (Actor actor in film.cast)
                        Console.WriteLine(actor.name);
                    Console.ReadLine();

                }
                foreach (Actor actor in actors)
                {
                    Console.WriteLine(actor.name);
                    foreach (Film film in actor.films)
                        Console.WriteLine(film.name);
                    Console.ReadLine();
                }
                Console.ReadLine();
            }



            //oscar.cast.Add(jim);
            //oscar.cast.Add(jane);
            //globe.cast.Add(jane);
            //globe.cast.Add(joe);
            //best.cast.Add(joe);
            //jim.name = "jim";
            //jane.name = "jane";
            //jim.films.Add(oscar);
            //jane.films.Add(oscar);
            //oscar.cast.Add(jim);
            //oscar.cast.Add(jane);

            //oscar.name = "The last Crusade";
            //if (oscar.findActor("joe"))
            //    Console.WriteLine("good");
            //else
            //    Console.WriteLine("bad");

        }
    }
}