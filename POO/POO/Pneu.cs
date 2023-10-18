﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public class Pneu
    {

        public int Aro { get; set; }
        public string Marca { get; set; }
        public int PSI { get; set; }
        public int PSIMaximo { get; set; }
        public int PSIMinimo { get; set; }
        public int Largura { get; set; }
        public int PercentualDeBorracha { get; set; }
        public int VelocidadeMaxima { get; set; }
        public int CargaAtual { get; set; }
        public int CargaMaxima { get; set; }
        public bool Estourado { get; set; }
        public bool Furado { get; set; }
        public int VelocidadeAtual { get; set; }
        public bool Estep { get; set; }

        public Pneu(int _aro, string _marca, int _pSI, int _pSIMaximo, int _largura, int _velocidadeMaxima, int _cargaMaxima, bool _estep = false)
        {
            Aro = _aro;
            Marca = _marca;
            PSI = _pSI;
            PSIMaximo = _pSIMaximo;
            PSIMinimo = 0;
            Largura = _largura;
            PercentualDeBorracha = 100;
            VelocidadeMaxima = _velocidadeMaxima;
            VelocidadeAtual = 0;
            CargaAtual = 0;
            CargaMaxima = _cargaMaxima;
            Estourado = false;
            Furado = false;
            Estep = _estep;

        }

        public void Acelerar(int _impulso)
        {
            if (Furado || Estourado)
            {
                string estado;

                estado = Furado ? "furado" : "estourado";

                Console.WriteLine($"O Pneu está {estado}");
                return;
            }

            VelocidadeAtual = VelocidadeAtual + _impulso;
            PercentualDeBorracha = PercentualDeBorracha - 2;

            if (VelocidadeAtual < 0)
                VelocidadeAtual = 0;

            if (PercentualDeBorracha < 0)
                PercentualDeBorracha = 0;

            EstourarPneu();
        }

        private void EstourarPneu()
        {
            if (PercentualDeBorracha < 30 || VelocidadeAtual > VelocidadeMaxima || PSI > PSIMaximo || CargaAtual > CargaMaxima)
            {
                Estourado = true;
                VelocidadeAtual = 0;
            }
        }

        public void Frear(int _impulso)
        {
            VelocidadeAtual = VelocidadeAtual - _impulso;
            PercentualDeBorracha = PercentualDeBorracha - 5;

            if (VelocidadeAtual < 0)
                VelocidadeAtual = 0;

            if (PercentualDeBorracha < 0)
                PercentualDeBorracha = 0;

            EstourarPneu();
        }
        public void Furar()
        {
            Furado = true;
        }
        public void Remendar()
        {
            Furado = false;
        }

        public void Exibir()
        {
            Console.WriteLine("\n \nAro " + Aro);
            Console.WriteLine("Marca " + Marca);
            Console.WriteLine("PSI " + PSI);
            Console.WriteLine("PSIMaximo " + PSIMaximo);
            Console.WriteLine("PSIMinimo " + PSIMinimo);
            Console.WriteLine("Largura " + Largura);
            Console.WriteLine("PercentualDeBorracha " + PercentualDeBorracha);
            Console.WriteLine("VelocidadeMaxima " + VelocidadeMaxima);
            Console.WriteLine("CargaAtual " + CargaAtual);
            Console.WriteLine("CargaMaxima " + CargaMaxima);
            Console.WriteLine("Estourado " + Estourado);
            Console.WriteLine("Furado " + Furado);
            Console.WriteLine("VelocidadeAtual " + VelocidadeAtual);
        }

    }
}
