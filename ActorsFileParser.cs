using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ActorsFileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            const string f = "uactresses.txt";
            const string o = "movieactresses.txt";
            /*
            foreach (var encodingInfo in Encoding.GetEncodings())
            {
                try
                {
                    var encoding = encodingInfo.GetEncoding();
                    var text = File.ReadAllText(f, encoding);
                    Console.WriteLine("{0} - {1}", encodingInfo.Name, text.Substring(0, 20));

                    // put break point and check if text is readable here
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed: {0}", encodingInfo.Name);
                }
            }
            */
            List<string> lines = new List<string>();
            int skip = 0;
            double linecount = 240;
            string name = "";
            List<string> movies = new List<string>();
            int aa = 0;
            int bb = 0;
            int cc = 0;
            int dd = 0;
            int ee = 0;
            int ff = 0;
            int gg = 0;
            int hh = 0;
            int ii = 0;
            int jj = 0;
            int kk = 0;
            int ll = 0;
            int mm = 0;
            int nn = 0;
            int oo = 0;
            int pp = 0;
            int qq = 0;
            int rr = 0;
            int ss = 0;
            int tt = 0;
            int uu = 0;
            int vv = 0;
            int ww = 0;
            int xx = 0;
            int yy = 0;
            int zz = 0;
            int other = 0;
            double actorcount = 0;
            
            using (StreamReader r = new StreamReader(f, Encoding.Unicode))
            {
                Console.WriteLine(Encoding.Unicode);
                using (StreamWriter w = new StreamWriter(o, false))
                {
                    string line;

                    bool nextActor = true;

                    while (skip < 240)
                    {
                        skip++;
                        r.ReadLine();
                    }
                    while ((line = r.ReadLine()) != null)
                    {
                        linecount++;
                        if (linecount % 100000 == 0)
                            Console.WriteLine(linecount);

                        int i = 0;
                        for (; i < line.Length; i++)
                        {
                            char c = line[i];
                            if (c == '\t')
                            {
                                if (nextActor)
                                {
                                    nextActor = false;
                                    name = line.Substring(0, i);
                                }
                                break;
                            }
                        }
                        int begin = i;
                        string movie = "";
                        bool nameFound = false;
                        for (; i < line.Length; i++)
                        {
                            char c = line[i];
                            if (c == '\"')
                                break;
                            if (c == '(')
                            {
                                if (i < line.Length - 1 && line.Substring(i + 1, 1) == "V")
                                {
                                    movie = "";
                                    break;
                                }
                                if (i < line.Length - 2 && line.Substring(i + 1, 2) == "TV")
                                {
                                    movie = "";
                                    break;
                                }
                            }
                            if (c == ')' && !nameFound)
                            {
                                movie = line.Substring(begin, i - begin + 1);
                                nameFound = true;
                                int j = 0;
                                while (movie[j] == '\t')
                                    j++;
                                movie = movie.Substring(j);
                                //Console.WriteLine("i=" + i);
                                //Console.WriteLine("b=" + begin);
                                //Console.WriteLine(movie);
                            }
                        }

                        if (movie != "")
                            movies.Add(movie);
                        //Console.WriteLine("ie=" + i);

                        if (line == "")
                        {
                            nextActor = true;
                            if (movies.Count == 0)
                                continue;

                            actorcount++;
                            if (name[0] == 'A')
                                aa++;
                            else if (name[0] == 'B')
                                bb++;
                            else if (name[0] == 'C')
                                cc++;
                            else if (name[0] == 'D')
                                dd++;
                            else if (name[0] == 'E')
                                ee++;
                            else if (name[0] == 'F')
                                ff++;
                            else if (name[0] == 'G')
                                gg++;
                            else if (name[0] == 'H')
                                hh++;
                            else if (name[0] == 'I')
                                ii++;
                            else if (name[0] == 'J')
                                jj++;
                            else if (name[0] == 'K')
                                kk++;
                            else if (name[0] == 'L')
                                ll++;
                            else if (name[0] == 'M')
                                mm++;
                            else if (name[0] == 'N')
                                nn++;
                            else if (name[0] == 'O')
                                oo++;
                            else if (name[0] == 'P')
                                pp++;
                            else if (name[0] == 'Q')
                                qq++;
                            else if (name[0] == 'R')
                                rr++;
                            else if (name[0] == 'S')
                                ss++;
                            else if (name[0] == 'T')
                                tt++;
                            else if (name[0] == 'U')
                                uu++;
                            else if (name[0] == 'V')
                                vv++;
                            else if (name[0] == 'W')
                                ww++;
                            else if (name[0] == 'X')
                                xx++;
                            else if (name[0] == 'Y')
                                yy++;
                            else if (name[0] == 'Z')
                                zz++;
                            else
                                other++;

                            w.WriteLine(name);
                            foreach (string m in movies)
                                w.WriteLine(m);
                            w.WriteLine();

                            movies.Clear();
                        }
                    }
                }
            }
            Console.WriteLine("aa=" + aa);
            Console.WriteLine("bb=" + bb);
            Console.WriteLine("cc=" + cc);
            Console.WriteLine("dd=" + dd);
            Console.WriteLine("ee=" + ee);
            Console.WriteLine("ff=" + ff);
            Console.WriteLine("gg=" + gg);
            Console.WriteLine("hh=" + hh);
            Console.WriteLine("ii=" + ii);
            Console.WriteLine("jj=" + jj);
            Console.WriteLine("kk=" + kk);
            Console.WriteLine("ll=" + ll);
            Console.WriteLine("mm=" + mm);
            Console.WriteLine("nn=" + nn);
            Console.WriteLine("oo=" + oo);
            Console.WriteLine("pp=" + pp);
            Console.WriteLine("qq=" + qq);
            Console.WriteLine("rr=" + rr);
            Console.WriteLine("ss=" + ss);
            Console.WriteLine("tt=" + tt);
            Console.WriteLine("uu=" + uu);
            Console.WriteLine("vv=" + vv);
            Console.WriteLine("ww=" + ww);
            Console.WriteLine("xx=" + xx);
            Console.WriteLine("yy=" + yy);
            Console.WriteLine("zz=" + zz);
            Console.WriteLine("other=" + other);
            Console.WriteLine("actorcount=" + actorcount);
            Console.ReadLine();
        }
    }
}
