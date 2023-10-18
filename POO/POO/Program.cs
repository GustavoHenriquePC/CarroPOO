﻿namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Pneu meuPneu = new Pneu (17, "MICHELIN", 33, 38, 25, 240, 500);
            Pneu troca;

            Carro carro = new Carro ("Chevrolet", "Sedan", "Branco", 1984, "qdw-9f34", 50, 100, 180);
            carro.Ligar();
            carro.Acelerar(5);
            carro.Acelerar(15);
            carro.Acelerar(6);
            carro.Desligar();
            carro.PneuDianteiroEsquerdo = meuPneu;
            carro.Ligar();
            carro.Acelerar(7);
            carro.Acelerar(7);
            carro.Frear(3);
            carro.Acelerar(6);
            carro.Frear(4);
            carro.Desligar();

            troca = carro.PneuDianteiroDireito;
            carro.PneuDianteiroDireito = carro.PneuDeEstep;
            carro.PneuDeEstep = troca;
            carro.Ligar();
            carro.Acelerar(7);
            carro.Acelerar(7);
            carro.Frear(3);
            carro.Acelerar(6);
            carro.Frear(4);
            carro.Desligar();

            troca = carro.PneuTraseiroDireito;
            carro.PneuTraseiroDireito = carro.PneuDeEstep;
            carro.PneuDeEstep = troca;
            carro.Ligar();
            carro.Acelerar(7);
            carro.Acelerar(7);
            carro.Frear(3);
            carro.Acelerar(6);
            carro.Frear(4);
            carro.Desligar();
            carro.Exibir();





        }
    }
}