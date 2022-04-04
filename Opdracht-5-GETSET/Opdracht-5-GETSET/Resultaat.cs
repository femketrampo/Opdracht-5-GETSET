using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht_5
{
    class Resultaat
    {
        private string naam;
        private double nederlands;
        private double frans;
        private double engels;

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }
        public double Nederlands
        {
            get { return nederlands; }
            set { nederlands = value; }
        }
        public double Frans
        {
            get { return frans; }
            set { frans = value; }
        }
        public double Engels
        {
            get { return engels; }
            set { engels = value; }
        }
    }
}