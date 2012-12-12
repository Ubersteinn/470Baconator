using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System;
using System.Security.Policy;
using System.Net;
using System.IO;
using System.Drawing;

namespace GUIForm
{
    class Actor
    {
        private string Name;
        private List<Film> Films;
        private bool Visited;
        private Film Connect;
        private TextBox outputBox;
        private ListView listView;
        private ImageList imageList;
        public Actor(string n = "none", List<Film> f = null, TextBox output = null, ListView listview = null, ImageList imagelist = null,  bool v = false)
        {
            Name = n;
            Films = f;
            outputBox = output;
            listView = listview;
            imageList = imagelist;
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
            bool first = true;

            listView.Items.Clear();

            while (a.Count > 1)             //display the path
            {
                Actor tema = a.Pop();

                addWithImage(tema.name, "nm");
                
                //outputBox.AppendText(Environment.NewLine + imageurl);
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.imdb.com/find?q=damon%2C+matt&s=all");

		        // execute the request
		        //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

		        // we will read data via the response stream
		        //Stream resStream = response.GetResponseStream();

                
                

                
                if (first)
                {
                    first = false;
                    listView.Items.Add("is in",0);
                }
                else
                    listView.Items.Add("who is in",0);
                outputBox.AppendText(Environment.NewLine + tema.name);
                outputBox.AppendText(Environment.NewLine + "|\n|");

                Film temf = f.Pop();
                addWithImage(temf.name, "tt");
                listView.Items.Add("with",1);
                outputBox.AppendText(Environment.NewLine + temf.name);
                outputBox.AppendText(Environment.NewLine + "|\n|");
            }
            Actor temaa = a.Pop();
            addWithImage(temaa.name, "nm");
            outputBox.AppendText(Environment.NewLine + temaa.name);
            outputBox.AppendText(Environment.NewLine + "degree of separation: " + degree);//show the degree of separation
            return degree;
        }
        public int DamerauLevenshteinDistance(string source, string target)
        {
            if (String.IsNullOrEmpty(source))
            {
                if (String.IsNullOrEmpty(target))
                {
                    return 0;
                }
                else
                {
                    return target.Length;
                }
            }
            else if (String.IsNullOrEmpty(target))
            {
                return source.Length;
            }

            var score = new int[source.Length + 2, target.Length + 2];

            var INF = source.Length + target.Length;
            score[0, 0] = INF;
            for (var i = 0; i <= source.Length; i++) { score[i + 1, 1] = i; score[i + 1, 0] = INF; }
            for (var j = 0; j <= target.Length; j++) { score[1, j + 1] = j; score[0, j + 1] = INF; }

            var sd = new SortedDictionary<char, int>();
            foreach (var letter in (source + target))
            {
                if (!sd.ContainsKey(letter))
                    sd.Add(letter, 0);
            }

            for (var i = 1; i <= source.Length; i++)
            {
                var DB = 0;
                for (var j = 1; j <= target.Length; j++)
                {
                    var i1 = sd[target[j - 1]];
                    var j1 = DB;

                    if (source[i - 1] == target[j - 1])
                    {
                        score[i + 1, j + 1] = score[i, j];
                        DB = j;
                    }
                    else
                    {
                        score[i + 1, j + 1] = Math.Min(score[i, j], Math.Min(score[i + 1, j], score[i, j + 1])) + 1;
                    }

                    score[i + 1, j + 1] = Math.Min(score[i + 1, j + 1], score[i1, j1] + (i - i1 - 1) + 1 + (j - j1 - 1));
                }

                sd[source[i - 1]] = i;
            }

            return score[source.Length + 1, target.Length + 1];
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

        public void addWithImage(string n, string NoT)//NoT either "nm" or "tt" if actor or film
        {
            Image image;
            try
            {
                image = Image.FromFile(n);
                imageList.Images.Add(image);
                listView.Items.Add(n, imageList.Images.Count - 1);
                return;
            }
            catch (Exception e)
            {

            }
       
            string tempn = n;
            int i = 0;
            while(i < tempn.Length)
            {
                if (tempn[i] == '(')
                {
                    while (tempn[i] != ')')
                        tempn = tempn.Remove(i, 1);
                }
                if (!char.IsLetterOrDigit(tempn, i) && !(tempn[i] == ' '))
                {
                    tempn = tempn.Remove(i, 1);
                    i--;
                }
                i++;
            }
            tempn = tempn.Replace(' ', '+');
            tempn = "http://www.imdb.com/find?q=" + tempn + "&s=" + NoT;

            Uri uri = new Uri(tempn);
            WebClient searchclient = new WebClient();
            //client.DownloadFile(uri, "websiteaaaa");

            string website = searchclient.DownloadString(uri);
            int minindex = website.IndexOf("<tr class=\"findResult odd\"> <td class=\"primary_photo\"> <a href=\"");
            if (minindex == -1)
            {
                Image blankimage;
                if(NoT == "nm")
                    blankimage = Image.FromFile("BlankActor");
                else
                    blankimage = Image.FromFile("BlankFilm");

                imageList.Images.Add(blankimage);
                listView.Items.Add(n, imageList.Images.Count - 1);
                return;
            }
            minindex = website.IndexOf("http://", minindex);
            int maxindex = website.IndexOf("height", minindex);
            //if (maxindex == -1)
              //  maxindex = website.IndexOf(".png", minindex);
            string imageurl = website.Substring(minindex, maxindex - minindex - 2);

            WebClient imageclient = new WebClient();
            try
            {
                imageclient.DownloadFile(imageurl, n);
                image = Image.FromFile(n);
                imageList.Images.Add(image);

                listView.Items.Add(n, imageList.Images.Count - 1);
            }
            catch (Exception e)
            {
                Image blankimage;
                if (NoT == "nm")
                    blankimage = Image.FromFile("BlankActor");
                else
                    blankimage = Image.FromFile("BlankFilm");

                imageList.Images.Add(blankimage);
                listView.Items.Add(n, imageList.Images.Count - 1);
            }
            
        }


    }
}
