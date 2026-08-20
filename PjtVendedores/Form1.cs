using PjtVendedores.Models;

namespace PjtVendedores
{
    public class Form1 : Form
    {
        private Vendedores vendedores;

        private TextBox txtId = null!;
        private TextBox txtNome = null!;
        private TextBox txtComissao = null!;

        private TextBox txtDia = null!;
        private TextBox txtQuantidade = null!;
        private TextBox txtValor = null!;

        private RichTextBox rtbResultado = null!;

        public Form1()
        {
            vendedores = new Vendedores(10);

            configurarForm();
            criarTitulo();
            criarCamposVendedor();
            criarCamposVenda();
            criarBotoes();
            criarResultado();
   
        }

        private void configurarForm()
        {
            Text = "Projeto Vendedores";

            Width = 900;
            Height = 700;

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void criarTitulo()
        {
            Label titulo = new Label();

            titulo.Parent = this;
            titulo.Text = "CONTROLE DE VENDEDORES";

            titulo.Left = 30;
            titulo.Top = 20;

            titulo.Width = 600;
            titulo.Height = 40;

            titulo.Font = new Font(
                "Arial",
                18,
                FontStyle.Bold
            );
        }

        private void criarCamposVendedor()
        {
            Label lblVendedor = new Label();

            lblVendedor.Parent = this;
            lblVendedor.Text = "Dados do Vendedor";
            lblVendedor.Left = 30;
            lblVendedor.Top = 80;
            lblVendedor.Width = 200;

            // ID

            Label lblId = new Label();

            lblId.Parent = this;
            lblId.Text = "ID:";
            lblId.Left = 30;
            lblId.Top = 120;

            txtId = new TextBox();

            txtId.Parent = this;
            txtId.Left = 130;
            txtId.Top = 115;
            txtId.Width = 150;

            // Nome

            Label lblNome = new Label();

            lblNome.Parent = this;
            lblNome.Text = "Nome:";
            lblNome.Left = 30;
            lblNome.Top = 160;

            txtNome = new TextBox();

            txtNome.Parent = this;
            txtNome.Left = 130;
            txtNome.Top = 155;
            txtNome.Width = 250;

            // Comissão

            Label lblComissao = new Label();

            lblComissao.Parent = this;
            lblComissao.Text = "Comissão (%):";
            lblComissao.Left = 30;
            lblComissao.Top = 200;
            lblComissao.Width = 100;

            txtComissao = new TextBox();

            txtComissao.Parent = this;
            txtComissao.Left = 130;
            txtComissao.Top = 195;
            txtComissao.Width = 150;
        }

        private void criarCamposVenda()
        {
            Label lblVenda = new Label();

            lblVenda.Parent = this;
            lblVenda.Text = "Registrar Venda";
            lblVenda.Left = 450;
            lblVenda.Top = 80;
            lblVenda.Width = 200;

            // Dia

            Label lblDia = new Label();

            lblDia.Parent = this;
            lblDia.Text = "Dia:";
            lblDia.Left = 450;
            lblDia.Top = 120;

            txtDia = new TextBox();

            txtDia.Parent = this;
            txtDia.Left = 570;
            txtDia.Top = 115;
            txtDia.Width = 150;

            // Quantidade

            Label lblQuantidade = new Label();

            lblQuantidade.Parent = this;
            lblQuantidade.Text = "Quantidade:";
            lblQuantidade.Left = 450;
            lblQuantidade.Top = 160;

            txtQuantidade = new TextBox();

            txtQuantidade.Parent = this;
            txtQuantidade.Left = 570;
            txtQuantidade.Top = 155;
            txtQuantidade.Width = 150;

            // Valor

            Label lblValor = new Label();

            lblValor.Parent = this;
            lblValor.Text = "Valor total:";
            lblValor.Left = 450;
            lblValor.Top = 200;

            txtValor = new TextBox();

            txtValor.Parent = this;
            txtValor.Left = 570;
            txtValor.Top = 195;
            txtValor.Width = 150;
        }

        private void criarBotoes()
        {
            Button btnCadastrar = new Button();

            btnCadastrar.Parent = this;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.Left = 30;
            btnCadastrar.Top = 260;
            btnCadastrar.Width = 120;
            btnCadastrar.Height = 30;

            btnCadastrar.Click += cadastrarVendedor;


            Button btnConsultar = new Button();

            btnConsultar.Parent = this;
            btnConsultar.Text = "Consultar";
            btnConsultar.Left = 160;
            btnConsultar.Top = 260;
            btnConsultar.Width = 120;
            btnConsultar.Height = 30;

            btnConsultar.Click += consultarVendedor;


            Button btnExcluir = new Button();

            btnExcluir.Parent = this;
            btnExcluir.Text = "Excluir";
            btnExcluir.Left = 290;
            btnExcluir.Top = 260;
            btnExcluir.Width = 120;
            btnExcluir.Height = 30;

            btnExcluir.Click += excluirVendedor;


            Button btnRegistrar = new Button();

            btnRegistrar.Parent = this;
            btnRegistrar.Text = "Registrar Venda";
            btnRegistrar.Left = 450;
            btnRegistrar.Top = 260;
            btnRegistrar.Width = 150;
            btnRegistrar.Height = 30;

            btnRegistrar.Click += registrarVenda;


            Button btnListar = new Button();

            btnListar.Parent = this;
            btnListar.Text = "Listar Vendedores";
            btnListar.Left = 610;
            btnListar.Top = 260;
            btnListar.Width = 150;
            btnListar.Height = 30;

            btnListar.Click += listarVendedores;
        }

        private void criarResultado()
        {
            Label lblResultado = new Label();

            lblResultado.Parent = this;
            lblResultado.Text = "Resultado";
            lblResultado.Left = 30;
            lblResultado.Top = 320;
            lblResultado.Width = 200;


            rtbResultado = new RichTextBox();

            rtbResultado.Parent = this;

            rtbResultado.Left = 30;
            rtbResultado.Top = 350;

            rtbResultado.Width = 800;
            rtbResultado.Height = 260;

            rtbResultado.ReadOnly = true;
        }

        // =========================
        // CADASTRAR
        // =========================

        private void cadastrarVendedor(
            object? sender,
            EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Informe um ID válido.");
                return;
            }

            if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Informe o nome.");
                return;
            }

            if (!double.TryParse(
                txtComissao.Text,
                out double comissao))
            {
                MessageBox.Show(
                    "Informe uma comissão válida."
                );

                return;
            }

            Vendedor vendedor =
                new Vendedor(
                    id,
                    txtNome.Text,
                    comissao
                );

            if (vendedores.addVendedor(vendedor))
            {
                MessageBox.Show(
                    "Vendedor cadastrado com sucesso!"
                );

                limparCampos();
            }
            else
            {
                MessageBox.Show(
                    "Não foi possível cadastrar.\n" +
                    "ID já existente ou limite de 10 vendedores atingido."
                );
            }
        }

        // =========================
        // CONSULTAR
        // =========================

        private void consultarVendedor(
            object? sender,
            EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Informe o ID.");
                return;
            }

            Vendedor pesquisa = new Vendedor(id, "", 0);
            Vendedor? vendedor = vendedores.searchVendedor(pesquisa);

            if (vendedor == null)
            {
                MessageBox.Show(
                    "Vendedor não encontrado."
                );

                return;
            }

            rtbResultado.Clear();

            rtbResultado.AppendText(
                $"ID: {vendedor.Id}\n"
            );

            rtbResultado.AppendText(
                $"Nome: {vendedor.Nome}\n"
            );

            rtbResultado.AppendText(
                $"Total vendido: {vendedor.valorVendas():C2}\n"
            );

            rtbResultado.AppendText(
                $"Comissão: {vendedor.valorComissao():C2}\n"
            );

            rtbResultado.AppendText(
                "\nVendas por dia:\n"
            );

            for (int i = 0;
                 i < vendedor.AsVendas.Length;
                 i++)
            {
                Venda venda =
                    vendedor.AsVendas[i];

                if (venda != null)
                {
                    rtbResultado.AppendText(
                        $"Dia {i + 1} | " +
                        $"Quantidade: {venda.Qtde} | " +
                        $"Valor: {venda.Valor:C2} | " +
                        $"Média: {venda.valorMedio():C2}\n"
                    );
                }
            }
        }

        // =========================
        // EXCLUIR
        // =========================

        private void excluirVendedor(
            object? sender,
            EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Informe o ID.");
                return;
            }

            Vendedor pesquisa =
                new Vendedor(id, "", 0);

            Vendedor? vendedor = vendedores.searchVendedor(pesquisa);

            if (vendedor == null)
            {
                MessageBox.Show(
                    "Vendedor não encontrado."
                );

                return;
            }

            if (vendedor.possuiVenda())
            {
                MessageBox.Show(
                    "Não é possível excluir.\n" +
                    "O vendedor possui vendas registradas."
                );

                return;
            }

            if (vendedores.delVendedor(vendedor))
            {
                MessageBox.Show(
                    "Vendedor excluído com sucesso."
                );

                limparCampos();
                rtbResultado.Clear();
            }
        }

        // =========================
        // REGISTRAR VENDA
        // =========================

        private void registrarVenda(
            object? sender,
            EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Informe o ID.");
                return;
            }

            Vendedor pesquisa =
                new Vendedor(id, "", 0);

            Vendedor? vendedor =
                vendedores.searchVendedor(pesquisa);

            if (vendedor == null)
            {
                MessageBox.Show(
                    "Vendedor não encontrado."
                );

                return;
            }

            if (!int.TryParse(txtDia.Text, out int dia)
                || dia < 1
                || dia > 31)
            {
                MessageBox.Show(
                    "Informe um dia entre 1 e 31."
                );

                return;
            }

            if (!int.TryParse(
                txtQuantidade.Text,
                out int quantidade))
            {
                MessageBox.Show(
                    "Quantidade inválida."
                );

                return;
            }

            if (!double.TryParse(
                txtValor.Text,
                out double valor))
            {
                MessageBox.Show(
                    "Valor inválido."
                );

                return;
            }

            Venda venda =
                new Venda(quantidade, valor);

            vendedor.registrarVenda(
                dia,
                venda
            );

            MessageBox.Show(
                "Venda registrada com sucesso!"
            );

            txtDia.Clear();
            txtQuantidade.Clear();
            txtValor.Clear();
        }

        // =========================
        // LISTAR
        // =========================

        private void listarVendedores(
            object? sender,
            EventArgs e)
        {
            rtbResultado.Clear();

            if (vendedores.Qtde == 0)
            {
                rtbResultado.Text =
                    "Nenhum vendedor cadastrado.";

                return;
            }

            rtbResultado.AppendText(
                "VENDEDORES\n\n"
            );

            for (int i = 0;
                 i < vendedores.Qtde;
                 i++)
            {
                Vendedor vendedor =
                    vendedores.OsVendedores[i];

                rtbResultado.AppendText(
                    $"ID: {vendedor.Id} | "
                );

                rtbResultado.AppendText(
                    $"Nome: {vendedor.Nome} | "
                );

                rtbResultado.AppendText(
                    $"Vendas: {vendedor.valorVendas():C2} | "
                );

                rtbResultado.AppendText(
                    $"Comissão: {vendedor.valorComissao():C2}\n"
                );
            }

            rtbResultado.AppendText(
                "\n-----------------------------------\n"
            );

            rtbResultado.AppendText(
                $"TOTAL VENDAS: " +
                $"{vendedores.valorVendas():C2}\n"
            );

            rtbResultado.AppendText(
                $"TOTAL COMISSÕES: " +
                $"{vendedores.valorComissao():C2}"
            );
        }

        private void limparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtComissao.Clear();

            txtId.Focus();
        }
    }
}