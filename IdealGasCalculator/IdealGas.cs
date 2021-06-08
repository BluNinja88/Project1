using System;
using System.Collections.Generic;
using System.Text;

namespace IdealGasCalculator
{
    class IdealGas
    {
        //Mass
        private double mass;
        public Double GetMass()
        {
            return mass;
        }
        public void SetMass(double mass)
        {
            this.mass = mass;
            Calc();
        }

       //Volume
        private double vol;
        public Double GetVol()
        {
            return vol;
        }
        public void SetVol(double vol)
        {
            this.vol = vol;
            Calc();
        }

        //Temperature
        private double temp;
        public Double GetTemp()
        {
            return temp;
        }
        public void SetTemp(double temp)
        {
            this.temp = temp;
            Calc();
        }

        //Molecular Weight
        private double molecularWeight;
        public Double GetMolecularWeight()
        {
            return molecularWeight;
        }
        public void SetMolecularWeight(double molecularWeight)
        {
            this.molecularWeight = molecularWeight;
            Calc();
        }

        //Pressure
        private double pressure;
        public Double GetPressure()
        {
            return pressure;
        }

        //Calculation Methods
        private void Calc()
        {
            double mol = mass;
            double kelvin = temp;
            double celcius = kelvin;
            double R = 8.3145;

            //Convert into Pascals
            double pressure = (mol * R * kelvin) / vol;
        }

    
    }
}
