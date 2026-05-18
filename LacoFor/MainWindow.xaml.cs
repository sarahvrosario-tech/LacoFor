using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LacoFor;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public decimal saldoInicial = 12340.00M;
    private string[] emoticons = { "🐯" ,"🍊" ,"💎" ,"💰", "🍒", "🔔" };
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void BotaoSorteio_OnClick(object sender, RoutedEventArgs e)

    {
        if (!int.TryParse(tbQuantidade.Text, out var quantidadeSorteios))
        {
            MessageBox.Show(("Coloque apenas valores numericos"));
            return;
        }
        
     

        if (quantidadeSorteios < 1)
        {
            quantidadeSorteios = 1;
            
        }
        var sorteador = new Random();
        for (int contador = 0; contador < quantidadeSorteios; contador++)
        {

            if (saldoInicial >= 10)
            {
                
                saldoInicial -= 10M;
                tbSaldo.Text = "R$" +saldoInicial.ToString();

                var numeroSorteado = sorteador.Next(40000001);

                if (numeroSorteado == 3)
                {
                    tbSlot1.Text = emoticons[0];
                    tbSlot2.Text = emoticons[0];
                    tbSlot3.Text = emoticons[0];
                    saldoInicial += 20M;
                    tbSaldo.Text = $"R$ {saldoInicial}";
                }
                else
                {
                    int slot1, slot2, slot3;
                    do
                    {
                         slot1 = sorteador.Next(emoticons.Length);
                         slot2 = sorteador.Next(emoticons.Length);
                         slot3 = sorteador.Next(emoticons.Length);
                        tbSlot1.Text = emoticons[slot1];
                        tbSlot2.Text = emoticons[slot2];
                        tbSlot3.Text = emoticons[slot3];
                    } while (slot1 == slot2 && slot2 == slot3);

                }
                
                await Task.Delay(1000);
            }
            else
            {
                MessageBox.Show("Você não tem saldo suficiente para realizar o sorteio!");
                break;
            }
            
            btnSorteio.IsEnabled = false;

        }

        btnSorteio.IsEnabled = true;
    }
}