using System;
using System.Collections.Generic;

namespace RobotGep
{
    class RobotGep
    {
        protected bool MukodikE;

        public void Leallit()
        {
            MukodikE = false;
        }

        public virtual void Mukodik()
        {
            Console.WriteLine("Megy a robotgép!");
            MukodikE = true;
        }
    }

    class TurmixGep : RobotGep
    {
        public new void Mukodik()
        {
            MukodikE = true;

            Console.WriteLine("Megy a turmixgép!");
        }

        void Turmixol(List<Gyumolcs> gyumolcsok) 
        {
            foreach (var item in gyumolcsok)
            {
                item.Mennyiseg--;
            }
        }
    }

    class KaveDaralo : RobotGep
    {
        public override void Mukodik()
        {
            MukodikE = true;

            Console.WriteLine("Megy a kavédaráló!");
        }

        public void KavetDaral(Kave kave) 
        {
            kave.Mennyiseg--;
        }
    }

    class Huto
    {
        public List<IElelmiszer> Elelmiszerek { get; set; }
    }

    interface IElelmiszer
    {
        DateTime LejaratiIdo { get; set; }
        bool FogyaszthatoE { get; }
        int Mennyiseg { get; set; }
    }

    class Gyumolcs : IElelmiszer
    {
        public DateTime LejaratiIdo { get; set; }

        public bool FogyaszthatoE
        {
            get { return LejaratiIdo > DateTime.Now; }
        }

        public int Mennyiseg { get; set; }
    }

    class Kave : IElelmiszer
    {
        public Kave(DateTime lejaratiIdo, int mennyiseg)
        {
            LejaratiIdo = lejaratiIdo;
            Mennyiseg = mennyiseg;
        }
        public DateTime LejaratiIdo { get; set; }
        public int Mennyiseg { get => _mennyiseg; set => _mennyiseg =  value < 0 ? 0 :  value ; }

        private int _mennyiseg;

        public bool FogyaszthatoE
        {
            get { return LejaratiIdo > DateTime.Now; }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            RobotGep robotGep = new RobotGep();
            TurmixGep turmixGep = new TurmixGep();
            KaveDaralo kvDaralo = new KaveDaralo();

            robotGep.Mukodik();
            turmixGep.Mukodik();
            kvDaralo.Mukodik();
        }
    }
}