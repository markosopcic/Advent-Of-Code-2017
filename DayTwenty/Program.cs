using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwenty
{
    class Program
    {
        static void Main(string[] args)
        {
            //drugi je malo bruteforce al sta ces
            Both();
        }

        public static void Both()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            string[] result = System.IO.File.ReadAllLines(fileName);
            Particle far = new Particle();
            far.xpos = long.MaxValue;
            far.ypos = long.MaxValue;
            far.zpos = long.MaxValue;
            List<Particle> particles = new List<Particle>();
            for(int i = 0; i < result.Length; i++)
            {
                string[] split = result[i].Split(' ');
                Particle par = new Particle();
                for(int j = 0; j < split.Length; j++)
                {
                    string[] split2 = split[j].Split(',');
                    long num1=0, num2=0, num3=0;
                    for(int x = 0; x < split2.Length; x++)
                    {
                        if (x == 0) num1 = long.Parse(split2[x].Substring(3));
                        if (x == 1) num2 = long.Parse(split2[x]);
                        if (x == 2) num3 = long.Parse(split2[x].Substring(0, split2[x].Length-1));
                    }
                    if (j == 0) { par.xpos = num1; par.ypos = num2; par.zpos = num3; }
                    else if (j == 1) { par.xvel = num1;par.yvel = num2;par.zvel = num3; }
                    else { par.xacc = num1;par.yacc = num2;par.zacc = num3; }
                }
                particles.Add(par);
            }
            List<Particle> parts2 = new List<Particle>();

            foreach(Particle part in particles)
            {
                parts2.Add(new Particle(part));
            }

            long t = 1000000;
            foreach(Particle part in parts2)
            {
                part.xpos = part.xpos + part.xvel * t + part.xacc * t * t / 2;
                part.ypos = part.ypos + part.yvel * t + part.yacc * t * t / 2;
                part.zpos = part.zpos + part.zvel * t + part.zacc * t * t / 2;
            }
            Console.WriteLine(parts2.IndexOf(parts2.Min()));

            for (int time = 0; time < t; time++)
            {
                foreach (Particle part in particles)
                {
                    part.calculateVelocityAndPosition();
                }
                List<Particle> parts = new List<Particle>(particles);
                List<Particle> collide = new List<Particle>();
                foreach(Particle part in particles)
                {
                    foreach(Particle part2 in particles)
                    {
                        if (part!=part2 && part.Collides(part2))
                        {
                            if (!collide.Contains(part)) collide.Add(part);
                            if(!collide.Contains(part2)) collide.Add(part2);
                        }
                    }
                }
                particles.RemoveAll(c => collide.Contains(c));
            }
            Console.WriteLine(particles.Count);
            Console.ReadKey();
        }
    }

    class Particle:IComparable<Particle>
    {
        public long xpos, ypos, zpos, xvel, yvel, zvel, xacc, yacc, zacc;

        public Boolean isCloser(Particle part)
        {
            if (part.distance() < this.distance()) return false;
            return true;
        }
        public Particle() { }
        public Particle(Particle part)
        {
            this.xpos = part.xpos;
            this.ypos = part.ypos;
            this.zpos = part.zpos;
            this.xvel = part.xvel;
            this.yvel = part.yvel;
            this.zvel = part.zvel;
            this.xacc = part.xacc;
            this.yacc = part.yacc;
            this.zacc = part.zacc;
        }

        public void calculateVelocityAndPosition()
        {
            long dist = distance();
            this.xvel += this.xacc;
            this.yvel += yacc;
            this.zvel += zacc;
            this.xpos += this.xvel;
            this.ypos += this.yvel;
            this.zpos += this.zvel;
        }

        public long distance()
        {
            return Math.Abs(xpos) + Math.Abs(ypos) + Math.Abs(zpos);
        }

        public int CompareTo(Particle other)
        {
            return this.distance().CompareTo(other.distance());
        }

        public Boolean Collides(Particle other)
        {
            if (this.xpos == other.xpos && this.ypos == other.ypos && this.zpos == other.zpos) return true;
            return false;
        }
    }
}
