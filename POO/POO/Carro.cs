using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public class Carro
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public int CapacidadeDoTanque { get; set; }
        public int PercentualDeCombustivel { get; set; }
        public bool Ligado { get; set; }
        public int VelocidadeMaxima { get; set; }
        public int VelocidadeAtual { get; set; }
        private Pneu pneuDianteiroEsquerdo;

        public Pneu PneuDianteiroEsquerdo 
        {
            get
            {
                return pneuDianteiroEsquerdo;
            }
            set
            {
                if (VelocidadeAtual > 0)
                    throw new Exception("Seu animal, desligue o carro!");

                if (Ligado)
                
                    throw new Exception("Seu Zé Ruela,. desligue o carro Boca de Jumento!");
                
                pneuDianteiroEsquerdo = value;
            }
        }
        public Pneu PneuDianteiroDireito { get; set; }
        public Pneu PneuTraseiroEsquedo { get; set; }
        public Pneu PneuTraseiroDireito { get; set; }
        public Pneu PneuDeEstep { get; set; }
        public Carro(string _marca, string _modelo, string _cor, int _ano, string _placa, int _capacidadeDoTanque, int _percentualDeCombustivel, int _velocidadeMaxima)
        {
            Marca = _marca;
            Modelo = _modelo;
            Cor = _cor;
            Ano = _ano;
            Placa = _placa;
            CapacidadeDoTanque = _capacidadeDoTanque;
            PneuDianteiroEsquerdo = new Pneu(13, "MICHELIN", 33, 38, 25, 240, 500);
            PneuDianteiroDireito = new Pneu(13, "MICHELIN", 33, 38, 25, 240, 500);
            PneuTraseiroEsquedo = new Pneu(13, "MICHELIN", 33, 38, 25, 240, 500);
            PneuTraseiroDireito = new Pneu(13, "MICHELIN", 33, 38, 25, 240, 500);
            PneuDeEstep = new Pneu(13, "MICHELIN", 33, 38, 20, 70, 300, true);
            PercentualDeCombustivel = _percentualDeCombustivel;
            Ligado = false;
            VelocidadeMaxima = _velocidadeMaxima;
        }
        public void Ligar()
        {
            if(PercentualDeCombustivel > 0)
            {
                Ligado = true;
                PercentualDeCombustivel = PercentualDeCombustivel - 1;
            }
        }
        public void Desligar()
        {
            Ligado = false;
            Parar();
           
        }
        public void Acelerar(int _impulso)
        {
            if (!Ligado)
            {
                Console.WriteLine(" O Carro está Desligado!");
                return;
            }
            if (CarroEstaOperacional())
            {
                PercentualDeCombustivel -= 5;
                VelocidadeAtual += _impulso;
                PneuTraseiroDireito.Acelerar(_impulso);
                PneuTraseiroEsquedo.Acelerar(_impulso);
                PneuDianteiroEsquerdo.Acelerar(_impulso);
                PneuDianteiroDireito.Acelerar(_impulso);
                CarroEstaOperacional();
            }          
        }
        public void Frear(int _impulso)
        {
            VelocidadeAtual -= _impulso;
            PneuTraseiroDireito.Frear(_impulso);
            PneuTraseiroEsquedo.Frear(_impulso);
            PneuDianteiroEsquerdo.Frear(_impulso);
            PneuDianteiroDireito.Frear(_impulso);
            
            if (VelocidadeAtual < 0)
                VelocidadeAtual = 0;     
        }
        public bool CarroEstaOperacional()
        {
            if (PercentualDeCombustivel == 0)
            {
                Console.WriteLine("O carro está sem Combustível");
                Desligar();
                return false;
            }
            if (PneuDianteiroDireito.Estourado || PneuDianteiroDireito.Furado)
            {
                Console.WriteLine("Problema com o Pneu dianteiro direito");
                Parar();
                return false;
            }
            if (PneuDianteiroEsquerdo.Estourado || PneuDianteiroEsquerdo.Furado)
            {
                Console.WriteLine("Problema com o Pneu dianteiro esquerdo");
                Parar();
                return false;
            }
            if (PneuTraseiroDireito.Estourado || PneuTraseiroDireito.Furado)
            {
                Console.WriteLine("Problema com o Pneu traseiro esquerdo");
                Parar();
                return false;
            }
            if (PneuTraseiroEsquedo.Estourado || PneuTraseiroEsquedo.Furado)
            {
                Console.WriteLine("Problema com o Pneu traseiro direito");
                Parar();
                return false;
            }
            return true;
        }
        public void Parar()
        {
            Frear(VelocidadeAtual);
        }
        public void Exibir()
        {
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine("Cor: " + Cor);
            Console.WriteLine("Ano: " + Ano);
            Console.WriteLine("Placa: " + Placa);
            Console.WriteLine("Capacidade Do Tanque: " + CapacidadeDoTanque);
            Console.WriteLine("Percentual De Combustivel: " + PercentualDeCombustivel);
            Console.WriteLine("lIGADO: " + Ligado);
            Console.WriteLine("Velocidade Atual: " + VelocidadeAtual);
            Console.WriteLine("Velocidade Maxima: " + VelocidadeMaxima);
            Console.WriteLine("\nPneu Dianteiro Esquerdo");
            PneuDianteiroEsquerdo.Exibir();
            Console.WriteLine("\nPneu Dianteiro Direito");
            PneuDianteiroDireito.Exibir();
            Console.WriteLine("\nPneu Traseiro Esquerdo");
            PneuTraseiroEsquedo.Exibir();
            Console.WriteLine("\nPneu Traseiro Direito");
            PneuTraseiroDireito.Exibir();
            Console.WriteLine("\nPneu De Estep");
            PneuDeEstep.Exibir();
        }   
    }
}
