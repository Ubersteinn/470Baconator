﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GUIForm
{
    public partial class Form1 : Form
    {

        const string ActorsFile = "UpdatedFile.txt";
        //const string UpdatedFile = "UpdatedFile.txt";
        string seedActor = "";
        string separatedActor = "";
        List<Film> films = new List<Film>();
        List<Actor> actors = new List<Actor>();
        AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void GetSeedActor_Click(object sender, EventArgs e)
        {
            seedActor = SeedActor1.Text;
            separatedActor = SeparatedActor1.Text;
            DegreeOfSeparation(seedActor, separatedActor);
        }

        private void DegreeOfSeparation(string seed, string separated)
        {
            //USER INTERFACE
            string input1 = seedActor;
            string input2 = separated;
            //Console.WriteLine("Select the first actor by it's corresponding number");
            //input1 = Console.ReadLine();
            //Console.WriteLine("Select the second actor by it's corresponding number");
            //input2 = Console.ReadLine();

            //string[] words = input1.Split(' ');
            // Console.WriteLine(words[1]+", "+words[0]);

            //input1 = words[1] + ", " + words[0];
            //Console.WriteLine(input1);

            Actor test = actors.Find(item => item.name == input1);
            //OutputBox.AppendText('\n' + test.name + " ");

            //words = input2.Split(' ');
            //input2 = words[1] + ", " + words[0];
            Actor test2 = actors.Find(item => item.name == input2);
            //int actor1 = int.Parse(input1);
            //int actor2 = int.Parse(input2);
            //if (actors[actor1].DegreeOfSeparation(actors[actor2], 1) != -1)
            if (test.DegreeOfSeparation(test2, 1) != -1)
                OutputBox.AppendText(Environment.NewLine + "\ngood ");
            else
                OutputBox.AppendText(Environment.NewLine + "\nbad ");

            foreach(Actor a in actors)
            {
                a.visited = false;
            }
            foreach (Film f in films)
            {
                f.visited = false;
            }
        }

        private void ImportActorsFilms()
        {
            //using (StreamReader r = new StreamReader(FilmFile))
            //{
            //    string line;
            //    int linecount = 0;
            //    while ((line = r.ReadLine()) != null)
            //    {
            //        linecount++;
            //        if (linecount % 10000 == 0)
            //        {
            //            OutputBox.AppendText(".");
            //        }

            //        films.Add(new Film(line, new List<Actor>()));


            //    }
            //}


            //OutputBox.AppendText(Environment.NewLine + "Imported Films");
                    
            //takes our sample file and indexes it into film and actor objects
            using (StreamReader r = new StreamReader(ActorsFile))
            {
                //using (StreamWriter u = new StreamWriter(UpdatedFile))
                //{
                
                string line;
                bool newactor = true;
                Actor currentActor = new Actor();
                Film currentFilm = new Film();
                int linecount = 0;
                //int idcount = 0;
                int indx = 0;
                bool checkID = false;

                while ((line = r.ReadLine()) != null)
                {
                    linecount++;
                    if (linecount % 10000 == 0)
                    {
                        OutputBox.AppendText(Environment.NewLine + linecount);
                    }

                    if (line == "")
                    {
                      //  u.WriteLine("");
                        newactor = true;
                        continue;
                    }

                    if (newactor == true)
                    {
                      //  u.WriteLine(line);
                        currentActor = new Actor(line, new List<Film>(), OutputBox);
                        actors.Add(currentActor);
                        newactor = false;
                    }
                    else
                    {
                        //u.WriteLine(line);
                        //int filmid = films.FindIndex(delegate(Film film) { return film.name.Equals(line); });

                        //if (filmid == -1)
                        //{
                            //  u.WriteLine(idcount);
                            //OutputBox.AppendText(Environment.NewLine + line + "Null when searched!!");
                            //  currentFilm = new Film(line, new List<Actor>());
                            //  films.Add(currentFilm);
                        //    idcount++;
                        //}
                        // else
                        // {
                            //   u.WriteLine(filmid);
                            //  currentFilm = films[filmid];
                        // }
                            
                        //currentFilm.cast.Add(currentActor);
                        // currentActor.films.Add(currentFilm);
                        if (checkID == false)
                        {
                            currentFilm = new Film(line, new List<Actor>());
                            checkID = true;
                            continue;
                        }
                        if (checkID == true)
                        {
                            indx = Convert.ToInt32(line);
                            if (indx >= films.Count)
                            {
                                films.Add(currentFilm);
                            }
                            films[indx].cast.Add(currentActor);
                            currentActor.films.Add(films[indx]);
                            checkID = false;
                        }

                    }
                }
            }
            OutputBox.AppendText(Environment.NewLine + "Imported Actors");
        }

        private void Initialize_Click(object sender, EventArgs e)
        {
            ImportActorsFilms();
            OutputBox.AppendText(Environment.NewLine + "Initialize complete");

            foreach (Actor actor in actors)
                autocomplete.Add(actor.name);

            SeparatedActor1.AutoCompleteCustomSource = autocomplete;
            SeedActor1.AutoCompleteCustomSource = autocomplete;

            OutputBox.AppendText(Environment.NewLine + "AutoComplete complete");

        }
    }
}
