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
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void BotaoSorteio_OnClick(object sender, RoutedEventArgs e)
    {
        var quantidadeTexto = tbQuantidade.Text;
        var quantidadeSorteio = Convert.ToInt32(quantidadeTexto);

        if (quantidadeSorteio < 1)
        {
            quantidadeSorteio = 1;
            
        }
        var sorteador = new Random();
        for (int contador = 0; contador < quantidadeSorteio; contador++)
        {

            tbResultado.Text = sorteador.Next(0, 40000000).ToString();
            await Task.Delay(1000);

        }
}
}