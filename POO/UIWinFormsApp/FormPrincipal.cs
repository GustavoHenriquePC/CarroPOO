using POO;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace UIWinFormsApp

{
    public partial class FormPrincipal : Form
    {
        Carro carro;
        public FormPrincipal()
        {
            InitializeComponent();
            carro = new Carro("Chevrolet", "Sedan", "Branco", 1984, "qdw-9f34", 50, 100, 180);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Exibir();

        }

        private void ExibirPneu(Pneu _pneu, TextBox _textBox)
        {
            _textBox.Text = "Aro: " + _pneu.Aro;
            _textBox.Text = _textBox.Text + "\r\nMarca: " + _pneu.Marca;
            _textBox.Text = _textBox.Text + "\r\nPSI: " + _pneu.PSI;
            _textBox.Text = _textBox.Text + "\r\nPSIMaximo: " + _pneu.PSIMaximo;
            _textBox.Text = _textBox.Text + "\r\nPSIMinimo: " + _pneu.PSIMinimo;
            _textBox.Text = _textBox.Text + "\r\nLargura: " + _pneu.Largura;
            _textBox.Text = _textBox.Text + "\r\nPercentualDeBorracha: " + _pneu.PercentualDeBorracha;
            _textBox.Text = _textBox.Text + "\r\nVelocidadeMaxima: " + _pneu.VelocidadeMaxima;
            _textBox.Text = _textBox.Text + "\r\nCargaAtual: " + _pneu.CargaAtual;
            _textBox.Text = _textBox.Text + "\r\nCargaMaxima: " + _pneu.CargaMaxima;
            _textBox.Text = _textBox.Text + "\r\nEstourado: " + _pneu.Estourado;
            _textBox.Text = _textBox.Text + "\r\nFurado: " + _pneu.Furado;
            _textBox.Text = _textBox.Text + "\r\nVelocidadeAtual: " + _pneu.VelocidadeAtual;
            _textBox.Text = _textBox.Text + "\r\nEstepe: " + _pneu.Estep;

            _textBox.BackColor = Color.Thistle;
            if (_pneu.Estourado)
            {
                _textBox.BackColor = Color.Red;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonLigar_Click(object sender, EventArgs e)
        {
            if (carro.Ligado)
                carro.Desligar();
            else
                carro.Ligar();

            Exibir();
        }

        private void Exibir()
        {
            textBoxExibir.Text = textBoxExibir.Text + "\r\nMarca: " + carro.Marca;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nModelo: " + carro.Modelo;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nCor: " + carro.Cor;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nAno: " + carro.Ano;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nPlaca: " + carro.Placa;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nCapacidade Do Tanque: " + carro.CapacidadeDoTanque;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nPercentual De Combustivel: " + carro.PercentualDeCombustivel;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nlIGADO: " + carro.Ligado;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nVelocidade Atual: " + carro.VelocidadeAtual;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nVelocidade Maxima: " + carro.VelocidadeMaxima;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nPneu Dianteiro Esquerdo";

            ExibirPneu(carro.PneuDianteiroDireito, textBoxPneuDianteiroDireito);
            ExibirPneu(carro.PneuDianteiroEsquerdo, textBoxPneuDianteiroEsquerdo);
            ExibirPneu(carro.PneuTraseiroDireito, textBoxPneuTraseiroDireito);
            ExibirPneu(carro.PneuTraseiroEsquedo, textBoxPneuTraseiroEsquerdo);
            ExibirPneu(carro.PneuDeEstep, textBoxPneuEstep);

            if (carro.Ligado)
                buttonLigar.Text = "Desligar";
            else
                buttonLigar.Text = "Ligar";
        }

        private void buttonAcelerar_Click(object sender, EventArgs e)
        {
            carro.Acelerar(Convert.ToInt32(textBoxImpulso.Text));
            Exibir();
        }

        private void buttonFrear_Click(object sender, EventArgs e)
        {
            carro.Frear(Convert.ToInt32(textBoxImpulso.Text));
            Exibir();
        }

        private void buttonTrocarPneu_Click(object sender, EventArgs e)
        {
            Pneu pneu = null;

            switch (comboBoxPneu.SelectedIndex)
            {
                case 0:
                    pneu = carro.PneuDianteiroDireito;
                    carro.PneuDianteiroDireito = carro.PneuDeEstep;
                    break;
                case 1:
                    pneu = carro.PneuDianteiroEsquerdo;
                    carro.PneuDianteiroEsquerdo = carro.PneuDeEstep;
                    break;
                case 2:
                    pneu = carro.PneuTraseiroDireito;
                    carro.PneuTraseiroEsquedo = carro.PneuDeEstep;
                    break;
                case 3:
                    pneu = carro.PneuTraseiroEsquedo;
                    carro.PneuTraseiroEsquedo = carro.PneuDeEstep;
                    break;
                default:
                    break;
            }

            if (pneu != null)
                carro.PneuDeEstep = pneu;

            Exibir();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAcelerar_Click_1(object sender, EventArgs e)
        {
            carro.Acelerar(Convert.ToInt32(textBoxImpulso.Text));
            Exibir();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonLigar_Click_1(object sender, EventArgs e)
        {
            if (carro.Ligado)
                carro.Desligar();
            else
                carro.Ligar();

            Exibir();
        }

        private void buttonFrear_Click_1(object sender, EventArgs e)
        {
            carro.Frear(Convert.ToInt32(textBoxImpulso.Text));
            Exibir();
        }

        private void buttonTrocarPneu_Click_1(object sender, EventArgs e)
        {
            try
            {
                Pneu pneu = null;

                switch (comboBoxPneu.SelectedIndex)
                {
                    case 0:
                        pneu = carro.PneuDianteiroDireito;
                        carro.PneuDianteiroDireito = carro.PneuDeEstep;
                        break;
                    case 1:
                        pneu = carro.PneuDianteiroEsquerdo;
                        carro.PneuDianteiroEsquerdo = carro.PneuDeEstep;
                        break;
                    case 2:
                        pneu = carro.PneuTraseiroDireito;
                        carro.PneuTraseiroEsquedo = carro.PneuDeEstep;
                        break;
                    case 3:
                        pneu = carro.PneuTraseiroEsquedo;
                        carro.PneuTraseiroEsquedo = carro.PneuDeEstep;
                        break;
                    default:
                        break;
                }

                if (pneu != null)
                    carro.PneuDeEstep = pneu;

                Exibir();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxExibir_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
